using System;

namespace postmarkspamcheck
{

  public class SpamcheckRule
  {
    public string score { get; set; }
    public string description { get; set; }
  }

  public class SpamcheckResult
  {
    public bool success { get; set; }
    public string score { get; set; }
    public string message { get; set; }
    public string report { get; set; }

    public SpamcheckRule[] rules { get; set; }
  }
}