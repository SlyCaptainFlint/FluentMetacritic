﻿using FluentAssertions;
using FluentMetacritic.Domain;
using FluentMetacritic.Scraping;
using FluentMetacritic.UnitTests.Scraping.Builders;
using System;
using Xunit;

namespace FluentMetacritic.UnitTests.Scraping
{
    [Trait("Category", "UnitTest")]
    public class AlbumSearchResultScraperTests
    {
        [Fact]
        public void GivenThereIsAnAlbumSearchResultWithAllFieldsSet_WhenItIsScraped_AnEntityIsCreated()
        {
            var data = new Album("Furious Angels", new DateTime(2003, 6, 3))
                           {
                               Description = "Best known for his 1995 single \"Clubbed To Death\"...",
                               Score = 63
                           };

            var html = new AlbumSearchResultBuilder()
                .WithName(data.Name)
                .WithDescription(data.Description)
                .WithReleaseDate(data.ReleaseDate)
                .WithScore(data.Score.Value)
                .Build();

            var scraper = new AlbumSearchResultScraper();

            var album = scraper.Scrape(html);

            album.ShouldBeEquivalentTo(data);
        }

        [Fact]
        public void GivenThereIsAnAlbumSearchResultWithMinimumFieldsSet_WhenItIsScraped_AnEntityIsCreated()
        {
            var data = new Album("Furious Angels", new DateTime(2003, 6, 3));

            var html = new AlbumSearchResultBuilder()
                .WithName(data.Name)
                .WithReleaseDate(data.ReleaseDate)
                .Build();

            var scraper = new AlbumSearchResultScraper();

            var album = scraper.Scrape(html);

            album.ShouldBeEquivalentTo(data);
        }
    }
}