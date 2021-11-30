using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Test
{    
    public class FinderTests
    {
        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var list = new List<Profile>();
            var finder = new Finder(list);

            var result = finder.Find(Distance.Closest);

            Assert.Null(result.P1);
            Assert.Null(result.P2);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var list = new List<Profile>() { sue };
            var finder = new Finder(list);

            var result = finder.Find(Distance.Closest);

            Assert.Null(result.P1);
            Assert.Null(result.P2);
        }

        [Fact]
        public void Returns_Closest_Two_For_Two_People()
        {
            var list = new List<Profile>() { sue, greg };
            var finder = new Finder(list);

            var result = finder.Find(Distance.Closest);

            Assert.Same(sue, result.P1);
            Assert.Same(greg, result.P2);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var list = new List<Profile>() { greg, mike };
            var finder = new Finder(list);

            var result = finder.Find(Distance.Furthest);

            Assert.Same(greg, result.P1);
            Assert.Same(mike, result.P2);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var list = new List<Profile>() { greg, mike, sarah, sue };
            var finder = new Finder(list);

            var result = finder.Find(Distance.Furthest);

            Assert.Same(sue, result.P1);
            Assert.Same(sarah, result.P2);
        }

        [Fact]
        public void Returns_Closest_Two_For_Four_People()
        {
            var list = new List<Profile>() { greg, mike, sarah, sue };
            var finder = new Finder(list);

            var result = finder.Find(Distance.Closest);

            Assert.Same(sue, result.P1);
            Assert.Same(greg, result.P2);
        }

        Profile sue = new Profile() {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
        Profile greg = new Profile() {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
        Profile sarah = new Profile() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        Profile mike = new Profile() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
    }
}