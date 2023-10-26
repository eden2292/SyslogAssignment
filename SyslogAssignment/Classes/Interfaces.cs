using System;
/// <summary>
/// Interface used for all radio items that can be added, ensures code can be expanded at a later date.
/// </summary>
interface IRadio
{
  string ChangeIpv4Address();
  string ChangeIpv6Address();
  int ChangePortNum();
}
