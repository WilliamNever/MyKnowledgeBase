Use Claims Authentication in Windows Authorization

// 1. add the followed to startup.cs, claiming to use windows authorization, add the policy and authorized handler
            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AuthorizedUsers",
                    policy=>policy.Requirements.Add(new AuthorizedUsersRequirement(HostingEnvironment))
                );

            });
            services.AddSingleton<IAuthorizationHandler, AuthorizedUsersHandler>();

// 2. 
    public class AuthorizedUsersRequirement : IAuthorizationRequirement
    {
        public AuthorizedUsersRequirement(IWebHostEnvironment env)  //here the env can be any type of a class, even if empty, no param.
        {
            Environment = env;
        }

        public IWebHostEnvironment Environment { get; set; }
    }

// 3. Authorized handler
    public class AuthorizedUsersHandler : AuthorizationHandler<AuthorizedUsersRequirement>
    {
        private IEnumerable<string> _authorizedUsers;
        private IEnumerable<string> _authorizedGroups;

        public AuthorizedUsersHandler(
            IEnumerable<string> authorizedUsers,
            IEnumerable<string> authorizedGroups)
        {
            _authorizedGroups = authorizedGroups;
            _authorizedUsers = authorizedUsers;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizedUsersRequirement requirement)
        {
            var isInUsers = _authorizedUsers.Any(x => x.Equals(context.User.Identity.Name, System.StringComparison.OrdinalIgnoreCase));
            var isInRole = context.User.IsInRole("CORP\\administrators"); //here is checking if a user is in a role/AD group.
            context.Succeed(requirement);
            return;
        }
    }

// 4. add the followed attribute to the controller/action where needs the Authorization
    [Authorize(Policy = "AuthorizedUsers")] 