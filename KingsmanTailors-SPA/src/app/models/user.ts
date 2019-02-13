export interface User {
  id: number;
  displayName: string;
  userId: string;
  username: string;
  gender: string;
  email: string;
  phoneNumber: string;
  accountConfirmed?: boolean;
  lockedOutEnabled?: boolean;
  lockedOutEnd?: Date;
  accessFailedCount?: number;
  roleCode: string;
  publicId: string;
  url: string;
  primarysid: string;
}
