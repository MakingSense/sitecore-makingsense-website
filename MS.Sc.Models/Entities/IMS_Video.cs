namespace MS.Sc.Models
{
    /// <summary>
    /// IMS_Video Class
    /// </summary>
    public partial interface IMS_Video
    {
        /// <summary>
        /// Gets or sets the video URL MP4.
        /// </summary>
        /// <value>
        /// The video URL MP4.
        /// </value>
        string Video_Url_Mp4 { get; }

        /// <summary>
        /// Gets or sets the video URL ogg.
        /// </summary>
        /// <value>
        /// The video URL ogg.
        /// </value>
        string Video_Url_Ogg { get; }

        /// <summary>
        /// Gets or sets the video URL webm.
        /// </summary>
        /// <value>
        /// The video URL webm.
        /// </value>
        string Video_Url_Webm { get; }
    }
}
