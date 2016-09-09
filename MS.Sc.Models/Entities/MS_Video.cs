namespace MS.Sc.Models
{
    using Sitecore.Data;
    using Sitecore.Data.Items;

    /// <summary>
    /// MS_Video class
    /// </summary>
    public partial class MS_Video
    {
        /// <summary>
        /// Gets or sets the video URL MP4.
        /// </summary>
        /// <value>
        /// The video URL MP4.
        /// </value>
        public virtual string Video_Url_Mp4
        {
            get
            {
                if (MP4_Video != null)
                {
                    MediaItem mediaItem = Sitecore.Context.Database.GetItem(new ID(MP4_Video.Id));

                    if (mediaItem != null)
                    {
                        return Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem);
                    }
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the video URL ogg.
        /// </summary>
        /// <value>
        /// The video URL ogg.
        /// </value>
        public virtual string Video_Url_Ogg
        {
            get
            {
                if (OGG_Video != null)
                {
                    MediaItem mediaItem = Sitecore.Context.Database.GetItem(new ID(OGG_Video.Id));

                    if (mediaItem != null)
                    {
                        return Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem);
                    }
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the video URL webm.
        /// </summary>
        /// <value>
        /// The video URL webm.
        /// </value>
        public virtual string Video_Url_Webm
        {
            get
            {
                if (WebM_Video != null)
                {
                    MediaItem mediaItem = Sitecore.Context.Database.GetItem(new ID(WebM_Video.Id));

                    if (mediaItem != null)
                    {
                        return Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem);
                    }
                }

                return string.Empty;
            }
        }
    }
}
