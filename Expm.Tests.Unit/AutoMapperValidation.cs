using AutoMapper;
using Expm.Core;
using Xunit;

namespace Expm.Tests.Unit
{
    /// <summary>
    /// Special test
    /// Use this test to validate the configuration of your auto mapper
    /// </summary>
    public class AutoMapperValidation
    {
        

        [Fact]
        public void TestAutoMapper()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new ExpmMapperProfile()));
            Mapper.AssertConfigurationIsValid();
        }

    }
}