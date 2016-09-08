namespace MS.Sc.Models
{
    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using System;

    /// <summary>
    /// GlassBase Class
    /// </summary>
    /// <seealso cref="MS.Sc.Models.IGlassBase" />
    public partial class GlassBase
    {
        /// <summary>
        /// Gets the name of the template.
        /// </summary>
        /// <value>
        /// The name of the template.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.TemplateName)]
        public virtual string TemplateName { get; private set; }

        /// <summary>
        /// Gets the template identifier.
        /// </summary>
        /// <value>
        /// The template identifier.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.TemplateId)]
        public virtual Guid TemplateId { get; private set; }

        /// <summary>
        /// Gets the full path.
        /// </summary>
        /// <value>
        /// The full path.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.FullPath)]
        public virtual string FullPath { get; private set; }
    }
}
