namespace BackendApi.Dto
{
    public readonly record struct UserDto
    {
        public string? Login { get; init; }
        public string? Password { get; init; }
        public string? PasswordConfirm { get; init; }
        public bool? Agree { get; init; }
        public CountryDto? Country { get; init; }
        public ProvinceDto? Province { get; init; }
    }
}
