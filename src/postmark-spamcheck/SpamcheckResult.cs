using System;

namespace postmarkspamcheck
{
  public class SpamcheckResult
  {
    public bool success { get; set; }
    public string score { get; set; }
    public string message { get; set; }
    public string report { get; set; }

    public string rules { get; set; }
  }
}