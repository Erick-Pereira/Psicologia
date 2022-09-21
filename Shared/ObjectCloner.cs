using System.Reflection;

namespace Shared
{
    public class ObjectCloner<T, W> where T : class, new()
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static W To(T item)
        {
            var propertiesOfT = typeof(T).GetProperties();
            var propertiesOfW = typeof(W).GetProperties();
            W w = Activator.CreateInstance<W>();

            foreach (var property in propertiesOfT)
            {
                object data = property.GetValue(item);

                PropertyInfo propertyToSet = propertiesOfW.FirstOrDefault(c => c.Name == property.Name && c.PropertyType == property.PropertyType);

                if (propertyToSet != null)
                {
                    propertyToSet.SetValue(w, data);
                }
            }
            return w;
        }
    }
}