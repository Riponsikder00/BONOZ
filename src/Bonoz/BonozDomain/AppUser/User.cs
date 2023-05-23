namespace BonozDomain.AppUser
{

    public class User
    {
        public User()
        {
            AppUserRoles = new HashSet<AppUserRole>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Login Id is Required")]
        public string LoginId { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be a minimum length of 6 and a maximum length of 20")]
        public string Password { get; set; }

        [Display(Name = "Name")]
        [StringLength(100), Required(ErrorMessage = "Name Id is Required")]
        public string Name { get; set; }

        [StringLength(100)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not a valid")]
        public string Email { get; set; }

        //this column will be used to check the active staus of the user
        public bool IsTeamMember { get; set; } = false;

        public DateTime ModifiedOn { get; set; }

        public bool IsTempPassword { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(17)]
        public string Phone { get; set; }

        public virtual ICollection<AppUserRole> AppUserRoles { get; set; }
        public virtual ICollection<AppUserModule> AppUserModules { get; set; }

        [NotMapped]
        public int SelectedRoleId { get; set; }
    }


    public class Shop
    {
        public int ShopId { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }


    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }


    public class Address
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }

    }

    public class AppUserRole
    {
        public int AppUserId { get; set; }
        public User AppUser { get; set; }

        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
    }


    public class AppRole
    {
        public AppRole()
        {
            AppUserRoles = new HashSet<AppUserRole>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public virtual ICollection<AppUserRole> AppUserRoles { get; set; }
    }

    public abstract class AppUserModuleBase
    {
        public int Id { get; set; }

        public ModuleId ModuleId { get; set; }
        public bool HasAccess { get; set; }
    }

    public class AppUserModule : AppUserModuleBase
    {
        public int AppUserId { get; set; }
        public User AppUser { get; set; }

        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
    }

    public class AppUserActivity
    {
        public int Id { get; set; }
        public string LoginId { get; set; }
        public DateTime LastActiveOn { get; set; }
        public int AppUserId { get; set; }
    }


    public class UserRestriction
    {
        public int Id { get; set; }

        [Display(Name = "User")]
        [Required(ErrorMessage = "User is Required")]
        public int AppUserId { get; set; }
        public virtual User AppUser { get; set; }

        [Display(Name = "Case")]
        public int CaseId { get; set; }
        //public virtual Case Case { get; set; }

        public bool RestrictStatus { get; set; }

        #region Audit Info

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [Required, StringLength(50)]
        public string RecordedBy { get; set; }

        [Required]
        public DateTime RecordedOn { get; set; }

        #endregion
    }

    public class ChangePasswordDTO
    {
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

    }


    public class AppUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AppUserRoleDesc { get; set; }

        public string Email { get; set; }
        public DateTime LastActiveDate { get; set; }

        public string Role { get; set; }

        public bool IsTeamMember { get; set; }

        public string LoginId { get; set; }

        public string IsTeamMemberFormatted
        {
            get
            {
                if (IsTeamMember == true)
                    return "Active";
                else return "Not Active";
            }
        }
    }

    #region Enums
    public enum Roles
    {
        None = 0,

        [Category("SA")]
        SuperAdmin = 1,  // Banaz

        [Category("AD")]
        Admin = 2,

        [Category("SO")]
        ShopOwner = 3,

        [Category("CMR")]
        Customer = 4,
    }

    public enum UserGroupEnum
    {
        None = 0,
        SA = 1,
        AD = 2,
        SO = 3,
        CMR = 4,
    }

    public enum ModuleId
    {
        [Display(Name = "General"), Description("General"), Category("None")]
        None = 0,

        [Display(Name = "Super Admin"), Description("Super Admin"), Category("SA")]
        SA = 1,

        [Display(Name = "Admin"), Description("Admin"), Category("AD")]
        AD = 2,

        [Display(Name = "Shop Owner"), Description("Shop Owner"), Category("SO")]
        SO = 3,

        [Display(Name = "Customer"), Description("Customer"), Category("CMR")]
        CMR = 3,
    }

    #endregion Enums
}
