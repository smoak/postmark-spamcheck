using System;

namespace postmarkspamcheck
{
  public class SpamcheckOptions
  {
    private SpamcheckOptions(string value) { Value = value; }

    public string Value { get; set; }

    public static SpamcheckOptions Short { get { return new SpamcheckOptions("short"); } }
    public static SpamcheckOptions Long { get { return new SpamcheckOptions("long"); } }

  }

  public class SpamcheckBody
  {
    public string email { get; set; }

    public string options { get; set; }
  }
}