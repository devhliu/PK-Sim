using OSPSuite.Core.Domain;
using OSPSuite.Core.Extensions;
using OSPSuite.Core.Serialization.Xml;
using OSPSuite.Serializer.Attributes;

namespace PKSim.Infrastructure.Serialization.Xml.Serializers
{
   public class ObjectPathXmlAttributeMapper : AttributeMapper<IObjectPath, SerializationContext>
   {
      public override string Convert(IObjectPath objectPath, SerializationContext context)
      {
         return objectPath == null ? string.Empty : objectPath.ToString();
      }

      public override object ConvertFrom(string attributeValue, SerializationContext context)
      {
         if (string.IsNullOrEmpty(attributeValue))
            return new ObjectPath();

         var objectPathFactory = context.Resolve<IObjectPathFactory>();
         return objectPathFactory.CreateObjectPathFrom(attributeValue.ToPathArray());
      }
   }
}