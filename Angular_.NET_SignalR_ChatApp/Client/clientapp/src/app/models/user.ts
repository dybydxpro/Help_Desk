export interface User {
    Id: number
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime? CreatedAt { get; set; }
        [Required]
        public DateTime? UpdatedAt { get; set;}
}
