// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace NWG.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

        private const string UserNameKey = "user_name_key";
        private static readonly string UserNameDefault = string.Empty;

        private const string PasswordKey = "password_key";
        private static readonly string PasswordDefault = string.Empty;

        private const string RoleKey = "role_key";
        private static readonly string RoleDefault = string.Empty;

		#endregion


        public static string UserName
		{
			get
			{
                return AppSettings.GetValueOrDefault(UserNameKey, UserNameDefault);
			}
			set
			{
                AppSettings.AddOrUpdateValue(UserNameKey, value);
			}
		}

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault(PasswordKey, PasswordDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(PasswordKey, value);
            }
        }

        public static string Role
        {
            get
            {
                return AppSettings.GetValueOrDefault(RoleKey, RoleDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(RoleKey, value);
            }
        }


	}
}