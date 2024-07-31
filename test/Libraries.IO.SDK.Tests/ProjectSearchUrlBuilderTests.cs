using FluentAssertions;
using NSubstitute.Core;

namespace Libraries.IO.SDK.Tests;
public class ProjectSearchUrlBuilderTests
{
    [Fact]
    public void When_query_parameter_is_null_then_q_included_in_url()
    {
        string expected = "https://libraries.io/api/search?q=";

        string actual = ProjectSearchUrlBuilder.Build(null, new ProjectSearchParameters());

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void When_query_parameter_has_value_then_url_matches_expected()
    {
        string expected = "https://libraries.io/api/search?q=arbitrary";

        string actual = ProjectSearchUrlBuilder.Build("arbitrary", new ProjectSearchParameters());

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void When_query_has_special_chars_then_url_matches_expected()
    {
        string query = "some?&=value";
        string expected = "https://libraries.io/api/search?q=some%3F%26%3Dvalue";

        string actual = ProjectSearchUrlBuilder.Build(query, new ProjectSearchParameters());

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void When_sort_paramters_is_null_then_url_matches_expected()
    {
        string expected = "https://libraries.io/api/search?q=";

        string actual = ProjectSearchUrlBuilder.Build(null, null);

        actual.Should().BeEquivalentTo(expected);
    }


    [Fact]
    public void When_sort_not_specified_then_url_does_not_contain_sort_paramter()
    {
        string actual = ProjectSearchUrlBuilder.Build(null, new ProjectSearchParameters());

        actual.Should().NotContain("sort=");
    }

    [Fact]
    public void When_sort_specified_then_url_matches_expected()
    {
        string expected = "https://libraries.io/api/search?q=&sort=created_at";
        var searchParameters = new ProjectSearchParameters
        {
            Sort = ProjectSortType.CreatedAt
        };
        string actual = ProjectSearchUrlBuilder.Build(null, searchParameters);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void When_keywords_specified_then_url_matches_expected()
    {
        string expected = "https://libraries.io/api/search?q=&keywords=arbitrary";
        var searchParameters = new ProjectSearchParameters
        {
            Keywords = "arbitrary"
        };
        string actual = ProjectSearchUrlBuilder.Build(null, searchParameters);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void When_languages_specified_then_url_matches_expected()
    {
        string expected = "https://libraries.io/api/search?q=&languages=arbitrary";
        var searchParameters = new ProjectSearchParameters
        {
            Languages = "arbitrary"
        };
        string actual = ProjectSearchUrlBuilder.Build(null, searchParameters);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void When_licenses_specified_then_url_matches_expected()
    {
        string expected = "https://libraries.io/api/search?q=&licenses=arbitrary";
        var searchParameters = new ProjectSearchParameters
        {
            Licenses = "arbitrary"
        };
        string actual = ProjectSearchUrlBuilder.Build(null, searchParameters);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void When_platforms_specified_then_url_matches_expected()
    {
        string expected = "https://libraries.io/api/search?q=&platforms=arbitrary";
        var searchParameters = new ProjectSearchParameters
        {
            Platforms = "arbitrary"
        };
        string actual = ProjectSearchUrlBuilder.Build(null, searchParameters);

        actual.Should().BeEquivalentTo(expected);
    }
}
