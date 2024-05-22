using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MpManagement.Identity.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Key]
        public virtual int Id { get; set; }

        //
        // Summary:
        //     Gets or sets the user name for this user.
        [ProtectedPersonalData]
        public virtual string? UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //
        // Summary:
        //     Gets or sets the email address for this user.
        [ProtectedPersonalData]
        public virtual string? Email { get; set; }


        //
        // Summary:
        //     Gets or sets a flag indicating if a user has confirmed their email address.
        //
        // Value:
        //     True if the email address has been confirmed, otherwise false.
        [PersonalData]
        public virtual bool EmailConfirmed { get; set; }

        //
        // Summary:
        //     Gets or sets a salted and hashed representation of the password for this user.
        public virtual string? PasswordHash { get; set; }

        //
        // Summary:
        //     A random value that must change whenever a users credentials change (password
        //     changed, login removed)
        public virtual string? SecurityStamp { get; set; }

        //
        // Summary:
        //     A random value that must change whenever a user is persisted to the store
        public virtual string? ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();


        //
        // Summary:
        //     Gets or sets a telephone number for the user.
        [ProtectedPersonalData]
        public virtual string? PhoneNumber { get; set; }

        //
        // Summary:
        //     Gets or sets a flag indicating if a user has confirmed their telephone address.
        //
        //
        // Value:
        //     True if the telephone number has been confirmed, otherwise false.
        [PersonalData]
        public virtual bool PhoneNumberConfirmed { get; set; }

        //
        // Summary:
        //     Gets or sets a flag indicating if two factor authentication is enabled for this
        //     user.
        //
        // Value:
        //     True if 2fa is enabled, otherwise false.
        [PersonalData]
        public virtual bool TwoFactorEnabled { get; set; }

        //
        // Summary:
        //     Gets or sets the number of failed login attempts for the current user.
        public virtual int AccessFailedCount { get; set; }

        //
        // Summary:
        //     Initializes a new instance of Microsoft.AspNetCore.Identity.IdentityUser`1.
        public ApplicationUser()
        {
            SecurityStamp = Guid.NewGuid().ToString();
        }

        //
        // Summary:
        //     Initializes a new instance of Microsoft.AspNetCore.Identity.IdentityUser`1.
        //
        // Parameters:
        //   userName:
        //     The user name.
        public ApplicationUser(string userName)
            : this()
        {
            UserName = userName;
        }

        //
        // Summary:
        //     Returns the username for this user.
        public override string ToString()
        {
            return UserName ?? string.Empty;
        }
    }
}
