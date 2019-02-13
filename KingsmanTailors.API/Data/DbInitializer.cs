using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using KingsmanTailors.API.Interfaces;
using KingsmanTailors.API.Models;
using KingsmanTailors.API.Utility;
using Microsoft.EntityFrameworkCore;

namespace KingsmanTailors.API.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly DataContext _context;
        public DbInitializer(DataContext context)
        {
            _context = context;
        }

        public async void Initialize()
        {
            // apply pending migrations if any
            if (_context.Database.GetPendingMigrations().Any())
            {
                _context.Database.Migrate();
            }

            // If there are user roles then no need to keep going
            if (await _context.UserRoles.AnyAsync())
            {
                return;
            }

            // Seed database if needed
            // Perform roles check first
            var doSeed = await seedRoles();
            if (!doSeed)
            {
                return;
            }

            seedFabrics();

            seedFit();

            seedFrontStyle();

            seedLabelStyle();

            seedLapelStyle();

            seedSalesTag();

            seedStyle();

            seedSuitSize();

            seedSuitType();

            seedType();

            seedVentStyle();

            seedSuit();

            seedSuitDetail();
        }

        #region "   Roles and Users "

        private async Task<bool> seedRoles()
        {
            var seeded = false;
            var su = false;
            var du = false;
            var sr = false;
            var gu = false;
            if (!await _context.Roles.AnyAsync(x => x.RoleName == SiteUtils.SuperUser))
            {
                // Create Super User role
                _context.Roles.Add(
                    new Models.Role
                    {
                        RoleAbbrev = "SU",
                        RoleId = Guid.NewGuid().ToString(),
                        RoleName = SiteUtils.SuperUser
                    });
                seeded = true;
                su = true;
            }

            if (!_context.Roles.Any(x => x.RoleName == SiteUtils.DemoUser))
            {
                // Create Demo User role
                _context.Roles.Add(
                    new Models.Role
                    {
                        RoleAbbrev = "DU",
                        RoleId = Guid.NewGuid().ToString(),
                        RoleName = SiteUtils.DemoUser
                    });
                seeded = true;
                du = true;
            }

            if (!_context.Roles.Any(x => x.RoleName == SiteUtils.SalesRep))
            {
                // Create Sales Rep role
                _context.Roles.Add(
                    new Models.Role
                    {
                        RoleAbbrev = "SR",
                        RoleId = Guid.NewGuid().ToString(),
                        RoleName = SiteUtils.SalesRep
                    });
                seeded = true;
                sr = true;
            }

            if (!_context.Roles.Any(x => x.RoleName == SiteUtils.GuestUser))
            {
                // Create Guest User role
                _context.Roles.Add(
                    new Models.Role
                    {
                        RoleAbbrev = "GU",
                        RoleId = Guid.NewGuid().ToString(),
                        RoleName = SiteUtils.GuestUser
                    });
                seeded = true;
                gu = true;
            }

            if (seeded)
            {
                _context.SaveChanges();

                if (su)
                {
                    seedUserForSu();
                }
                if (du)
                {
                    seedUserForDu();
                }
                if (sr)
                {
                    seedUserForSr();
                }
                if (gu)
                {
                    seedUserForGu();
                }
            }

            return seeded;
        }

        private void seedUserForSu()
        {
            var roleCode = _context.Roles.FirstOrDefault(x => x.RoleName == SiteUtils.SuperUser).RoleId;
            var userId = Guid.NewGuid().ToString();
            _context.Users
            .Add(setSecurityStamp(
                   new Models.User
                   {
                       AccessFailedCount = 0,
                       AccountConfirmed = false,
                       LockedOutEnabled = false,
                       LockedOutEnd = DateTime.Parse("1900-01-01T00:00:00"),
                       DisplayName = "The Bigdadi",
                       Email = "bigdadi@foo.bar",
                       Gender = "Male",
                       PhoneNumber = "01322 100000",
                       UserId = userId,
                       Username = "bigdadi",
                   }, "Ktadmin_123!"));
            _context.UserRoles
            .Add(new UserRole
            {
                RoleId = roleCode,
                UserId = userId
            });

            userId = Guid.NewGuid().ToString();
            _context.Users
            .Add(setSecurityStamp(
                    new Models.User
                    {
                        AccessFailedCount = 0,
                        AccountConfirmed = false,
                        LockedOutEnabled = false,
                        LockedOutEnd = DateTime.Parse("1900-01-01T00:00:00"),
                        DisplayName = "Madam Abie",
                        Email = "madamabie@foo.bar",
                        Gender = "Female",
                        PhoneNumber = "01322 100100",
                        UserId = userId,
                        Username = "madamabie"
                    }, "Ktadmin_123!"));
            _context.UserRoles
            .Add(new UserRole
            {
                RoleId = roleCode,
                UserId = userId
            });
            _context.SaveChanges();
        }

        private void seedUserForDu()
        {
            var roleCode = _context.Roles.FirstOrDefault(x => x.RoleName == SiteUtils.DemoUser).RoleId;
            var userId = Guid.NewGuid().ToString();
            _context.Users
            .Add(setSecurityStamp(
                    new Models.User
                    {
                        AccessFailedCount = 0,
                        AccountConfirmed = false,
                        LockedOutEnabled = false,
                        LockedOutEnd = DateTime.Parse("1900-01-01T00:00:00"),
                        DisplayName = "Kingsman Demo",
                        Email = "ktdemo@foo.bar",
                        Gender = "Female",
                        PhoneNumber = "01322 200000",
                        UserId = userId,
                        Username = "ktdemo"
                    }, "Ktdemo123!"));
            _context.UserRoles
            .Add(new UserRole
            {
                RoleId = roleCode,
                UserId = userId
            });
            _context.SaveChanges();
        }

        private void seedUserForSr()
        {
            var roleCode = _context.Roles.FirstOrDefault(x => x.RoleName == SiteUtils.SalesRep).RoleId;
            var userId = Guid.NewGuid().ToString();
            _context.Users
            .Add(setSecurityStamp(
                    new Models.User
                    {
                        AccessFailedCount = 0,
                        AccountConfirmed = false,
                        LockedOutEnabled = false,
                        LockedOutEnd = DateTime.Parse("1900-01-01T00:00:00"),
                        DisplayName = "Joseph Gordon-Levitt",
                        Email = "joelevitt@foo.bar",
                        Gender = "Male",
                        PhoneNumber = "01322 400000",
                        UserId = userId,
                        Username = "joelevitt"
                    }, "Password123!"));
            _context.UserRoles
            .Add(new UserRole
            {
                RoleId = roleCode,
                UserId = userId
            });

            userId = Guid.NewGuid().ToString();
            _context.Users
            .Add(setSecurityStamp(
                    new Models.User
                    {
                        AccessFailedCount = 0,
                        AccountConfirmed = false,
                        LockedOutEnabled = false,
                        LockedOutEnd = DateTime.Parse("1900-01-01T00:00:00"),
                        DisplayName = "James Edward Franco",
                        Email = "jamesfranco@foo.bar",
                        Gender = "Male",
                        PhoneNumber = "01322 400100",
                        UserId = userId,
                        Username = "jamesfranco"
                    }, "Password123!"));
            _context.UserRoles
            .Add(new UserRole
            {
                RoleId = roleCode,
                UserId = userId
            });

            userId = Guid.NewGuid().ToString();
            _context.Users
            .Add(setSecurityStamp(
                    new Models.User
                    {
                        AccessFailedCount = 0,
                        AccountConfirmed = false,
                        LockedOutEnabled = false,
                        LockedOutEnd = DateTime.Parse("1900-01-01T00:00:00"),
                        DisplayName = "Viola Davis",
                        Email = "violadavis@foo.bar",
                        Gender = "Female",
                        PhoneNumber = "01322 400200",
                        UserId = userId,
                        Username = "violadavis"
                    }, "Password123!"));
            _context.UserRoles
            .Add(new UserRole
            {
                RoleId = roleCode,
                UserId = userId
            });

            userId = Guid.NewGuid().ToString();
            _context.Users
            .Add(setSecurityStamp(
                    new Models.User
                    {
                        AccessFailedCount = 0,
                        AccountConfirmed = false,
                        LockedOutEnabled = false,
                        LockedOutEnd = DateTime.Parse("1900-01-01T00:00:00"),
                        DisplayName = "Adepero Oduye",
                        Email = "adepero@foo.bar",
                        Gender = "Female",
                        PhoneNumber = "01322 400300",
                        UserId = userId,
                        Username = "adepero"
                    }, "Password123!"));
            _context.UserRoles
            .Add(new UserRole
            {
                RoleId = roleCode,
                UserId = userId
            });

            userId = Guid.NewGuid().ToString();
            _context.Users
            .Add(setSecurityStamp(
                    new Models.User
                    {
                        AccessFailedCount = 0,
                        AccountConfirmed = false,
                        LockedOutEnabled = false,
                        LockedOutEnd = DateTime.Parse("1900-01-01T00:00:00"),
                        DisplayName = "Jen Aniston",
                        Email = "jenaniston@foo.bar",
                        Gender = "Female",
                        PhoneNumber = "01322 400400",
                        UserId = userId,
                        Username = "jenaniston"
                    }, "Password123!"));
            _context.UserRoles
            .Add(new UserRole
            {
                RoleId = roleCode,
                UserId = userId
            });
            _context.SaveChanges();
        }

        private void seedUserForGu()
        {
            var roleCode = _context.Roles.FirstOrDefault(x => x.RoleName == SiteUtils.GuestUser).RoleId;
            var userId = Guid.NewGuid().ToString();
            _context.Users
            .Add(setSecurityStamp(
                    new Models.User
                    {
                        AccessFailedCount = 0,
                        AccountConfirmed = false,
                        LockedOutEnabled = false,
                        LockedOutEnd = DateTime.Parse("1900-01-01T00:00:00"),
                        DisplayName = "Chiwetel Umeadi Ejiofor",
                        Email = "chiwetel@foo.bar",
                        Gender = "Male",
                        PhoneNumber = "01322 600000",
                        UserId = userId,
                        Username = "chiwetel"
                    }, "Password123!"));
            _context.UserRoles
            .Add(new UserRole
            {
                RoleId = roleCode,
                UserId = userId
            });

            userId = Guid.NewGuid().ToString();
            _context.Users
            .Add(setSecurityStamp(
                    new Models.User
                    {
                        AccessFailedCount = 0,
                        AccountConfirmed = false,
                        LockedOutEnabled = false,
                        LockedOutEnd = DateTime.Parse("1900-01-01T00:00:00"),
                        DisplayName = "Sandra Annette Bullock",
                        Email = "sbullock@foo.bar",
                        Gender = "Female",
                        PhoneNumber = "01322 600100",
                        UserId = userId,
                        Username = "sbullock"
                    }, "Password123!"));
            _context.UserRoles
            .Add(new UserRole
            {
                RoleId = roleCode,
                UserId = userId
            });

            userId = Guid.NewGuid().ToString();
            _context.Users
            .Add(setSecurityStamp(
                    new Models.User
                    {
                        AccessFailedCount = 0,
                        AccountConfirmed = false,
                        LockedOutEnabled = false,
                        LockedOutEnd = DateTime.Parse("1900-01-01T00:00:00"),
                        DisplayName = "Halle Maria Berry",
                        Email = "halleberry@foo.bar",
                        Gender = "Female",
                        PhoneNumber = "01322 600200",
                        UserId = userId,
                        Username = "halleberry"
                    }, "Password123!"));
            _context.UserRoles
            .Add(new UserRole
            {
                RoleId = roleCode,
                UserId = userId
            });
            _context.SaveChanges();
        }

        private User setSecurityStamp(User user, string password)
        {
            using (var hmac = new HMACSHA512())
            {
                user.SecurityStamp = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            return user;
        }

        #endregion

        private void seedFabrics()
        {
            // add fabric
            if (!_context.Fabrics.Any())
            {
                // Create all fabric types
                _context.Fabrics.AddRangeAsync(new[]
                {
                    new Fabric
                    {
                        Description = "Cotton material",
                        FabricName = "Cotton"
                    },
                    new Fabric
                    {
                        Description = "Linen material",
                        FabricName = "Linen"
                    },
                    new Fabric
                    {
                        Description = "Polyester material - easy care",
                        FabricName = "Polyester"
                    },
                    new Fabric
                    {
                        Description = "Silk - premium material",
                        FabricName = "Silk"
                    },
                    new Fabric
                    {
                        Description = "Wool - for cold weather",
                        FabricName = "Wool"
                    }
                });
                _context.SaveChanges();
            }
        }

        private void seedFit()
        {
            //add occasion fit
            if (!_context.OccasionFittings.Any())
            {
                // Create all occasion fit
                _context.OccasionFittings.AddRangeAsync(new[]
                {
                    new OccasionFit
                    {
                        Description = "Slim Fit",
                        FitName = "Slim Fit"
                    },
                    new OccasionFit
                    {
                        Description = "Tailored Fit",
                        FitName = "Tailored Fit"
                    },
                    new OccasionFit
                    {
                        Description = "Heritage",
                        FitName = "Heritage"
                    },
                    new OccasionFit
                    {
                        Description = "Regular",
                        FitName = "Regular"
                    },
                    new OccasionFit
                    {
                        Description = "Classic",
                        FitName = "Classic"
                    },
                    new OccasionFit
                    {
                        Description = "Performance",
                        FitName = "Performance"
                    },
                    new OccasionFit
                    {
                        Description = "Luxury",
                        FitName = "Luxury"
                    }
                });
                _context.SaveChanges();
            }
        }

        private void seedFrontStyle()
        {
            // add front styles
            if (!_context.FrontStyles.Any())
            {
                // add all front styles
                _context.FrontStyles.AddRangeAsync(new[]
                {
                    new FrontStyle {FrontName = "Single Breasted"},
                    new FrontStyle {FrontName = "Double Breasted"}
                });
                _context.SaveChanges();
            }
        }

        private void seedLabelStyle()
        {
            // add lapel style
            if (!_context.OccasionLabels.Any())
            {
                // add all lapel styles
                _context.OccasionLabels.AddRangeAsync(new[]
                {
                    new OccasionLabel { Description="Wear for business functions", LabelName = "Business"},
                    new OccasionLabel { Description="For casual functions", LabelName = "Casual"},
                    new OccasionLabel { Description="Exotic colors and styles", LabelName = "Novelty"}
                });
                _context.SaveChanges();
            }
        }

        private void seedLapelStyle()
        {
            // add lapel style
            if (!_context.LapelStyles.Any())
            {
                // add all lapel styles
                _context.LapelStyles.AddRangeAsync(new[]
                {
                    new LapelStyle {LapelName = "Notched"},
                    new LapelStyle {LapelName = "Peaked"},
                    new LapelStyle {LapelName = "Shawl"}
                });
                _context.SaveChanges();
            }
        }

        private void seedSalesTag()
        {
            // add sales tags
            if (!_context.SalesTags.Any())
            {
                // add all sales tags
                _context.SalesTags.AddRangeAsync(new[]
                {
                    new SalesTag {ApplyPriceAdjust = false, PriceAdjust = 0.0, TagName = "Best Seller"},
                    new SalesTag {ApplyPriceAdjust = false, PriceAdjust = 0.0, TagName = "New Design"},
                    new SalesTag {ApplyPriceAdjust = true, PriceAdjust = -0.2, TagName = "12-Hr Only"},
                    new SalesTag {ApplyPriceAdjust = true, PriceAdjust = -0.3, TagName = "24-Hr Only"},
                    new SalesTag {ApplyPriceAdjust = true, PriceAdjust = -0.5, TagName = "Black Friday"},
                    new SalesTag {ApplyPriceAdjust = true, PriceAdjust = -0.2, TagName = "Boxing Day"},
                    new SalesTag {ApplyPriceAdjust = true, PriceAdjust = -0.4, TagName = "Clearance"},
                    new SalesTag {ApplyPriceAdjust = false, PriceAdjust = 0.0, TagName = "End of Line"}
                });
                _context.SaveChanges();
            }
        }

        private void seedStyle()
        {
            // add occasion style
            if (!_context.OccasionStyles.Any())
            {
                // create all occasion styles
                _context.OccasionStyles.AddRangeAsync(new[]
                {
                    new OccasionStyle {StyleName = "Solid Color"},
                    new OccasionStyle {StyleName = "Striped"},
                    new OccasionStyle {StyleName = "Checked"},
                    new OccasionStyle {StyleName = "Plaid"}
                });
                _context.SaveChanges();
            }
        }

        private void seedSuitSize()
        {
            // add suit sizes
            if (!_context.SuitSizes.Any())
            {
                // add all suit sizes
                _context.SuitSizes.AddRangeAsync(new[]
                {
                    new SuitSize {PriceAdjustIndex = 0.0, SizeName = "36R"},
                    new SuitSize {PriceAdjustIndex = 0.0, SizeName = "36S"},
                    new SuitSize {PriceAdjustIndex = 0.0, SizeName = "38R"},
                    new SuitSize {PriceAdjustIndex = 0.0, SizeName = "38S"},
                    new SuitSize {PriceAdjustIndex = 0.0, SizeName = "40R"},
                    new SuitSize {PriceAdjustIndex = 0.0, SizeName = "40S"},
                    new SuitSize {PriceAdjustIndex = 0.0, SizeName = "42R"},
                    new SuitSize {PriceAdjustIndex = 0.0, SizeName = "42S"},
                    new SuitSize {PriceAdjustIndex = 0.0, SizeName = "44R"},
                    new SuitSize {PriceAdjustIndex = 0.0, SizeName = "44L"},
                    new SuitSize {PriceAdjustIndex = 0.0, SizeName = "60R"},
                    new SuitSize {PriceAdjustIndex = 0.0, SizeName = "62R"}
                });
                _context.SaveChanges();
            }
        }

        private void seedSuitType()
        {
            // Add suit types
            if (!_context.SuitTypes.Any())
            {
                // Create all suit types
                _context.SuitTypes.AddRangeAsync(new[]
                {
                    new SuitType
                    {
                        Description = "Bespoke",
                        SuitTypeName = "Bespoke"
                    },
                    new SuitType
                    {
                        Description = "Ready to wear",
                        SuitTypeName = "Ready to wear"
                    },
                    new SuitType
                    {
                        Description = "Separates",
                        SuitTypeName = "Separates"
                    },
                    new SuitType
                    {
                        Description = "Jacket",
                        SuitTypeName = "Jacket"
                    },
                    new SuitType
                    {
                        Description = "Blazer",
                        SuitTypeName = "Blazer"
                    }
                });
                _context.SaveChanges();
            }
        }

        private void seedType()
        {
            // add occasion type
            if (!_context.OccasionTypes.Any())
            {
                // create all occasion types
                _context.OccasionTypes.AddRangeAsync(new[]
                {
                    new OccasionType
                    {
                        ColorName = "Black",
                        ColorValue = "#000000",
                        LabelId = (int) enLabelType.Business
                    },
                    new OccasionType
                    {
                        ColorName = "Light Grey",
                        ColorValue = "#eeeeee",
                        LabelId = (int) enLabelType.Business
                    },
                    new OccasionType
                    {
                        ColorName = "Dark Grey",
                        ColorValue = "#dddddd",
                        LabelId = (int) enLabelType.Business
                    },
                    new OccasionType
                    {
                        ColorName = "Navy",
                        ColorValue = "#0000ff",
                        LabelId = (int) enLabelType.Business
                    },
                    new OccasionType
                    {
                        ColorName = "Green",
                        ColorValue = "#ff0000",
                        LabelId = (int) enLabelType.Casual
                    },
                    new OccasionType
                    {
                        ColorName = "Brown",
                        ColorValue = "#34ee3d",
                        LabelId = (int) enLabelType.Casual
                    },
                    new OccasionType
                    {
                        ColorName = "Red",
                        ColorValue = "#00ff00",
                        LabelId = (int) enLabelType.Casual
                    },
                    new OccasionType
                    {
                        ColorName = "Grey",
                        ColorValue = "#eeeeee",
                        LabelId = (int) enLabelType.Casual
                    },
                    new OccasionType
                    {
                        ColorName = "Tweed",
                        ColorValue = "#ededed",
                        LabelId = (int) enLabelType.Casual
                    },
                    new OccasionType
                    {
                        ColorName = "Yellow",
                        ColorValue = "#ffff00",
                        LabelId = (int) enLabelType.Novelty
                    }
                });
                _context.SaveChanges();
            }
        }

        private void seedVentStyle()
        {
            // add vent style
            if (!_context.VentStyles.Any())
            {
                // add all vent styles
                _context.VentStyles.AddRangeAsync(new[]
                {
                    new VentStyle { VentName = "Single (Centre Vent)"},
                    new VentStyle { VentName = "Double"},
                    new VentStyle { VentName = "Ventless"}
                });
                _context.SaveChanges();
            }
        }

        private void seedSuit()
        {
            // add suit
            if (!_context.Suits.Any())
            {
                // add all vent styles
                _context.Suits.AddRangeAsync(new[]
                {
                    new Suit { Description="Dinner Suit", FitId=1, FrontId=1, LapelId=2, StyleId=1, SuitTypeId=1, TypeId=1, VentId = 1},
                    new Suit { Description="Heritage occasion fit suit", FitId=3, FrontId=2, LapelId=1, StyleId=1, SuitTypeId=2, TypeId=1, VentId = 2},
                    new Suit { Description="Simple city worker suit", FitId=4, FrontId=1, LapelId=1, StyleId=3, SuitTypeId=3, TypeId=1, VentId = 1},
                    new Suit { Description="Simple city worker suit", FitId=4, FrontId=2, LapelId=1, StyleId=2, SuitTypeId=3, TypeId=1, VentId = 1}
                });
                _context.SaveChanges();
            }
        }

        private void seedSuitDetail()
        {
            // add suit
            if (!_context.SuitDetails.Any())
            {
                // add all vent styles
                _context.SuitDetails.AddRangeAsync(new[]
                {
                    new SuitDetail { Price=1599.95, Qty=10, TagId=1, InStock=true, SuitId=1},
                    new SuitDetail { Price=959.99, Qty=5, TagId=2, InStock=true, SuitId=2},
                    new SuitDetail { Price=299.99, Qty=145, TagId=4, InStock=true, SuitId=3},
                    new SuitDetail { Price=299.99, Qty=145, TagId=4, InStock=false, SuitId=4}
                });
                _context.SaveChanges();
            }
        }
    }
}
