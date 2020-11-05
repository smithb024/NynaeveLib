namespace NynaeveLib.Enumerations
{
  using System;
  using System.Reflection;

  public class EnumerationDescriptionAttribute : Attribute
  {
    public EnumerationDescriptionAttribute(string description)
    {
    }

    public string Description
    {
      get;
      set;
    }

    //has a string property Description. It is set in the constructor from a string argument. Attribute is in the System library.
    //There is a static property to get the description:

    public static string GetDescription(Enum enumerationValue)
    {
      Type enumerationType = enumerationValue.GetType();
      FieldInfo fieldAttributes =
        enumerationType.GetField(
          enumerationValue.ToString());

      EnumerationDescriptionAttribute[] attributeList =
        fieldAttributes.GetCustomAttributes(
          typeof(EnumerationDescriptionAttribute),
          false)
          as EnumerationDescriptionAttribute[];

      // Return the description or a string from enumeration if no description is present.
      if (attributeList != null && attributeList.Length > 0)
      {
        return attributeList[0].Description;
      }
      else
      {
        return enumerationValue.ToString();
      }
    }

    //To use:
    //Call EnumerationDescriptionAttribute.GetDescription(EnumObject) to get the description.
    //Add the tag [EnumerationDescriptionAttribute("description string")] to each enumerator
  }
}