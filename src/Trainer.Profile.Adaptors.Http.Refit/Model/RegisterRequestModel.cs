﻿namespace Trainer.Profile.Adaptors.Http.Refit.Model;

internal class RegisterRequestModel
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set;
    }
}