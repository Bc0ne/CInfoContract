﻿namespace Contract.API.Bootstraper
{
    using AutoMapper;
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Initialize an auto-mapping profiles.
        /// </summary>
        public static void Initialize()
        {
            string[] profiles =
            {
                 "Contract.Web.Models",
                 "Contract.API"
            };

            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.AddProfiles(profiles));
            Mapper.AssertConfigurationIsValid();
        }
    }
}
