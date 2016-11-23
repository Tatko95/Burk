using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.ObjectBuilder;
using System.Collections.Generic;

namespace Burk.Core.Concrete.Unity
{
    public class BuildTrackingExtension : UnityContainerExtension
    {
        #region METHODS
        #region UnityContainerExtension
        protected override void Initialize()
        {
            this.Context.Strategies.AddNew<BuildTrackingStrategy>(UnityBuildStage.TypeMapping);
        }
        #endregion

        public static IBuildTrackingPolicy GetPolicy(IBuilderContext context)
        {
            return context.Policies.Get<IBuildTrackingPolicy>(context.BuildKey, true);
        }

        private static IBuildTrackingPolicy SetPolicy(IBuilderContext context)
        {
            IBuildTrackingPolicy policy = new BuildTrackingPolicy();
            context.Policies.SetDefault<IBuildTrackingPolicy>(policy);
            return policy;
        }
        #endregion

        #region NESTED TYPES (ENUMS, STRUCTURES, CLASSES)
        public interface IBuildTrackingPolicy : IBuilderPolicy
        {
            #region PROPERTIES
            Stack<object> BuildKeys { get; }
            #endregion
        }

        private class BuildTrackingPolicy : IBuildTrackingPolicy
        {
            #region CONSTRUCTORS
            public BuildTrackingPolicy()
            {
                this.BuildKeys = new Stack<object>();
            }
            #endregion

            #region PROPERTIES
            public Stack<object> BuildKeys { get; private set; }
            #endregion
        }

        private class BuildTrackingStrategy : BuilderStrategy
        {
            #region METHODS
            #region BuilderStrategy
            public override void PreBuildUp(IBuilderContext context)
            {
                IBuildTrackingPolicy policy = GetPolicy(context);
                if (policy == null)
                    policy = SetPolicy(context);
                policy.BuildKeys.Push(context.BuildKey);
            }

            public override void PostBuildUp(IBuilderContext context)
            {
                IBuildTrackingPolicy policy = GetPolicy(context);
                if ((policy != null) && (policy.BuildKeys.Count > 0))
                    policy.BuildKeys.Pop();
            }
            #endregion
            #endregion
        }
        #endregion
    }
}
