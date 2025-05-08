namespace EcommercePlaygroundTests.Components
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ComponentTypeAttribute : Attribute
    {
        public Type ComponentType { get; set; }

        public ComponentTypeAttribute(Type componentType)
        {
            ComponentType = componentType;
        }
    }
}
