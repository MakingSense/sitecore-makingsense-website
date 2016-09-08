namespace MS.Sc.Models
{
    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using System;

    /// <summary>
    /// IGlassBase Interface
    /// </summary>
    public partial interface IGlassBase
    {
                /// <summary>
        /// Gets the name of the template.
        /// </summary>
        /// <value>
        /// The name of the template.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.TemplateName)]
        string TemplateName { get; }

        /// <summary>
        /// Gets the template identifier.
        /// </summary>
        /// <value>
        /// The template identifier.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.TemplateId)]
        Guid TemplateId { get; }

        /// <summary>
        /// Gets the full path.
        /// </summary>
        /// <value>
        /// The full path.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.FullPath)]
        string FullPath { get; }
    }
}
