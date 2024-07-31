using System.Text;
using System.Text.Encodings.Web;

namespace Libraries.IO.SDK;
public static class ProjectSearchUrlBuilder
{
    public static string Build(string? query, ProjectSearchParameters? searchParameters)
    {
        var sb = new StringBuilder("https://libraries.io/api/search?q=");

        if(!string.IsNullOrEmpty(query))
        {
            string q = UrlEncoder.Default.Encode(query);
            sb.Append(q);
        }

        if (searchParameters != null)
        {
            if (searchParameters.Sort != ProjectSortType.None)
            {
                sb.Append("&sort=");
                sb.Append(searchParameters.Sort);
            }

            AppendSearchParameter(sb, "keywords", searchParameters.Keywords);
            AppendSearchParameter(sb, "languages", searchParameters.Languages);
            AppendSearchParameter(sb, "licenses", searchParameters.Licenses);
            AppendSearchParameter(sb, "platforms", searchParameters.Platforms);
        }

        return sb.ToString();
    }

    private static void AppendSearchParameter(StringBuilder sb, string name, string value)
    {
        if (string.IsNullOrEmpty(value))
            return;

        string encodedValue = UrlEncoder.Default.Encode(value);
        sb.Append('&');
        sb.Append(name);
        sb.Append('=');
        sb.Append(encodedValue);
    }
}