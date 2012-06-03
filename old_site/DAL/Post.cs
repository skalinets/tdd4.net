namespace Site.DAL
{
    public partial class Post
    {
        public string BriefText
        {
            get
            {
                int indicatorPosition = GetIndicatorPosition();
                var shouldBeTruncated = indicatorPosition > -1;
                if (shouldBeTruncated)
                {
                    return Text.Substring(0, indicatorPosition);
                }
                return Text;
            }
        }

        private int GetIndicatorPosition()
        {
            const string cutIndicator = "<!--more-->";
            return Text.IndexOf(cutIndicator);
        }

        public bool HasMoreTag { get { return GetIndicatorPosition() > -1; } }
    }
}