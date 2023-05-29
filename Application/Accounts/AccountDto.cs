using System;
using System.Collections.Generic;
using System.Linq;
using Application.Roles;
using Core.Entities;

namespace Application.Accounts;

public readonly struct AccountDto
{
    public AccountDto(Account account, string callerCorporateEmail)
    {
        Id = account.Id;
        CorporateEmail = account.CorporateEmail;
        FirstName = account.FirstName;
        LastName = account.LastName;
        MiddleName = account.MiddleName;
        IsBlocked = account.IsBlocked;
        Roles = account.AccountRoles.Select(x => new RoleDto(x.Role));

        // Refactor: use Instant in controllers instead of date time
        CreationDate = account.CreatedAt.ToDateTimeUtc();
        CanChangeAccountState = account.CorporateEmail == callerCorporateEmail;
    }

    public long Id { get; }

    public string CorporateEmail { get; }

    public DateTime CreationDate { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string? MiddleName { get; }

    public bool IsBlocked { get; }

    public IEnumerable<RoleDto> Roles { get; }

    public bool CanChangeAccountState { get; }
}