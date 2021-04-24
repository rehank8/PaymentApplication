export class UserDetail {
  public PKUserId: number;
  public FirstName: string;
  public MiddleName: string;
  public LastName: string;
  public EmailId: string;
  public PhoneNumber: string;
  public Password: string;
  public RegisteredDate: Date;
  public LastLoginDate: Date;
  public Location: string;
  public Country: string;
  public IsActive: boolean;
  public ImageUrl: string;
  public Gender: string;
  public FKRoleId: string;
  public OTP: number;
  public OTPGeneratedDateTime: Date;
}
