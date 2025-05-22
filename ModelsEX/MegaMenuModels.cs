namespace MegaMenu360.ModelsEX
{


    public class MegaMenuTopLink
    {
        public Guid TopLinkID { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string RightOffset { get; set; } = "10px";

        public string Icon { get; set; } = string.Empty;
        public List<MegaMenuGroup> Groups { get; set; } = new();
    }

    public class MegaMenuGroup
    {
        public Guid GroupID { get; set; } = Guid.NewGuid();
        public List<MegaMenuItem> Items { get; set; } = new();
    }

    public class MegaMenuItem
    {
        public Guid ItemID { get; set; } = Guid.NewGuid();
        public string Type { get; set; } = "link";  // link, title, separator, image
        public string? Text { get; set; }
        public string? Url { get; set; }
        public string? Src { get; set; }
        public string? Icon { get; set; }
        public string? Alt { get; set; }
        public string? Class { get; set; }
    }



    //public class MegaMenuTopLink
    //{
    //    public string Name { get; set; } = "";
    //    public string Icon { get; set; } = "";
    //    public List<MegaMenuGroup> Groups { get; set; } = new();
    //    public string? RightOffset { get; set; } // e.g. "5px"
    //}

    //public class MegaMenuGroup
    //{
    //    public List<MegaMenuItem> Items { get; set; } = new();
    //}

    //public class MegaMenuItem
    //{
    //    public string? Type { get; set; }            // "link", "title", "separator", "image"
    //    public string? Text { get; set; }            // Display text
    //    public string? Url { get; set; }             // For link
    //    public string? Src { get; set; }             // For image
    //    public string? Alt { get; set; }             // For image alt text
    //    public string? Icon { get; set; }            // New: FA icon (e.g., "fa-solid fa-chart-line")
    //    public string? Class { get; set; }           // New: Additional Bootstrap or custom class
    //}

}
