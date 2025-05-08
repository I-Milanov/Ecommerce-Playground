using System.Reflection;

namespace EcommercePlaygroundTests.Components
{
    public class FormModel
    {
        public List<FormField> GetFormFields() {
            var fields = new List<FormField>();
            var properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                var formField = new FormField();

                SetLabel(property, formField);
                SetComponentType(property, formField);
                SetRequiredStatus(property, formField);

                fields.Add(formField);
            }

            return fields;
        }

        private void SetLabel(PropertyInfo property, FormField formField)
        {
            var labelAttr = property.GetCustomAttribute<LabelAttribute>();

            if (labelAttr != null)
            {
                formField.Label = labelAttr.Label;
            }
            else
            {
                throw new InvalidOperationException($"Property '{property.Name}' in '{GetType().Name}' is missing [Label] attribute.");
            }
        }

        private void SetComponentType(PropertyInfo property, FormField formField)
        {
            var labelAttr = property.GetCustomAttribute<ComponentTypeAttribute>();

            if (labelAttr != null)
            {
                formField.ControlType = labelAttr.ComponentType;
            }
            else
            {
                throw new InvalidOperationException($"Property '{property.Name}' in '{GetType().Name}' is missing [Label] attribute.");
            }
        }

        private void SetRequiredStatus(PropertyInfo property, FormField formField)
        {
            var labelAttr = property.GetCustomAttribute<RequiredAttribute>();

            if (labelAttr != null)
            {
                formField.IsRequired = true;
            }
            else
            {
                formField.IsRequired = false;
            }
        }
    }

    public class FormField
    {
        public string Label { get; set; }
        public bool? IsRequired { get; set; }
        public Type ControlType { get; set; }
    }
}
