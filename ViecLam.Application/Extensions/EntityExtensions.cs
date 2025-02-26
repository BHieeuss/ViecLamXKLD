using System.Net;

namespace ViecLam.Application.Extensions
{
    public static class EntityExtensions
    {
        /// <summary>
        /// Map data from source entity to target entity
        /// </summary>
        /// <typeparam name="TTarget">Destination entity, which data of source entity will be mapped to</typeparam>
        /// <param name="source">Current entity</param>
        /// <param name="ignoreNull">If true, null value of source properties will not be mapped to target and keep original data, otherwise, map null to target property</param>
        /// <returns>New value of target</returns>
        public static TTarget? MapTo<TTarget>(this object source, bool ignoreNull = false) where TTarget : class?, new()
        {
            var target = new TTarget();
            return MapTo(source, target, ignoreNull);
        }

        /// <summary>
        /// Map data from source entity to target entity
        /// </summary>
        /// <typeparam name="TSource">Current entity</typeparam>
        /// <typeparam name="TTarget">Destination entity, which data of source entity will be mapped to</typeparam>
        /// <param name="source">Current entity</param>
        /// <param name="target">Destination entity, which data of source entity will be mapped to</param>
        /// <param name="ignoreNull">If true, null value of source will be mapped to target, otherwise, keep target original data</param>
        /// <returns>New value of target</returns>
        public static TTarget? MapTo<TSource, TTarget>(this TSource source, TTarget target, bool ignoreNull = false) where TSource : class? where TTarget : class?, new()
        {
            if (source is null) return null;

            // Create new target when target is null
            target ??= new TTarget();
            // Get source properties
            var sourceProperties = source.GetType().GetProperties();

            // Get target properties
            var targetProperties = target.GetType().GetProperties();
            foreach (var sourceProperty in sourceProperties)
            {
                // Find matched property name and type of source and target
                var targetProperty = Array.Find(targetProperties, p => p.Name == sourceProperty.Name && p.PropertyType == sourceProperty.PropertyType);
                if (targetProperty is null)
                    // Find by name property
                    targetProperty = Array.Find(targetProperties, p => p.Name == sourceProperty.Name);
                if (targetProperty != null && targetProperty.CanWrite)
                {
                    // Get source property value
                    var value = sourceProperty.GetValue(source);
                    // If ignore null, will keep original target data
                    if (ignoreNull && value == null) value = targetProperty.GetValue(target);
                    try
                    {
                        // Mapping from source to target
                        targetProperty.SetValue(target, value);
                    }
                    catch (Exception)
                    {
                        //var message = MsgConst.UN_SUP_MAP.FormatMsg(sourceProperty.Name, sourceProperty.PropertyType, targetProperty.PropertyType);
                        //throw new CustomException().WithMessageCode(MsgCode.ERR_INTERNAL_SERVER).WithDetails(message).WithStatusCode((int)HttpStatusCode.InternalServerError);
                    }
                }
            }

            return target;
        }
    }
}
