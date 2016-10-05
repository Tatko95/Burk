using Burk.Core.Abstract.Log;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.ObjectBuilder;
using System;
using System.Diagnostics;
using System.Linq;

namespace Burk.Core.Concrete.Unity
{
    internal class LogCreationExtension<T, U> : UnityContainerExtension
            where U : ILogFactory, new()
    {
        #region METHODS
        #region UnityContainerExtension
        protected override void Initialize()
        {
            this.Context.Strategies.AddNew<LogCreationStrategy<T, U>>(UnityBuildStage.PreCreation);
        }
        #endregion
        #endregion

        #region NESTED TYPES (ENUMS, STRUCTURES, CLASSES)
        private class LogCreationStrategy<TI, UI> : BuilderStrategy
            where UI : ILogFactory, new()
        {
            #region PROPERTIES
            public bool IsPolicySet { get; private set; }
            #endregion

            #region METHODS
            private static Type GetLogType(IBuilderContext context)
            {
                Type logType = typeof(TI);
                BuildTrackingExtension.IBuildTrackingPolicy buildTrackingPolicy = BuildTrackingExtension.GetPolicy(context);
                if ((buildTrackingPolicy != null) && (buildTrackingPolicy.BuildKeys.Count >= 2))
                    logType = ((NamedTypeBuildKey)buildTrackingPolicy.BuildKeys.ElementAt(1)).Type;
                else
                {
                    StackTrace stackTrace = new StackTrace();
                    //first two are in the log creation strategy, can skip over them
                    for (int i = 2; i < stackTrace.FrameCount; i++)
                    {
                        StackFrame frame = stackTrace.GetFrame(i);
                        logType = frame.GetMethod().DeclaringType;
                        //Console.WriteLine(logType.FullName);
                        if (!logType.FullName.StartsWith("Microsoft.Practices"))
                            break;
                    }
                }
                return logType;
            }

            #region BuilderStrategy
            public override void PreBuildUp(IBuilderContext context)
            {
                Type typeToBuild = context.BuildKey.Type;
                if (typeof(TI).Equals(typeToBuild))
                    if (context.Policies.Get<LogBuildPlanPolicy>(context.BuildKey) == null)
                    {
                        Type typeForLog = LogCreationStrategy<TI, UI>.GetLogType(context);
                        ILogFactory factory = new UI();
                        IBuildPlanPolicy policy = new LogBuildPlanPolicy(typeForLog, factory);
                        context.Policies.Set(policy, context.BuildKey);
                        this.IsPolicySet = true;
                    }
            }

            public override void PostBuildUp(IBuilderContext context)
            {
                if (this.IsPolicySet)
                {
                    context.Policies.Clear<LogBuildPlanPolicy>(context.BuildKey);
                    this.IsPolicySet = false;
                }
            }
            #endregion
            #endregion  
        }

        private class LogBuildPlanPolicy : IBuildPlanPolicy
        {
            #region FIELDS
            private ILogFactory logFactory;
            #endregion

            #region CONSTRUCTORS
            public LogBuildPlanPolicy(Type logType, ILogFactory factory)
            {
                this.LogType = logType;
                logFactory = factory;
            }
            #endregion

            #region PROPERTIES
            public Type LogType { get; private set; }
            #endregion

            #region METHODS
            #region IBuildPlanPolicy
            public void BuildUp(IBuilderContext context)
            {
                if (context.Existing == null)
                    context.Existing = logFactory.GetLogger(this.LogType);
            }
            #endregion
            #endregion
        }
        #endregion
    }
}
