using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConventionsHandicap.Shared
{
    public class CreateUserRequest
    {
        [Required]
        [JsonProperty("workspaceId")]
        public Guid? WorkspaceId { get; set; }
        [Required]
        [JsonProperty("userRole")]
        public ConventionsHandicapUserRole? UserRole { get; set; }
        [Required]
        [JsonProperty("userEmail")]
        public string? UserEmail { get; set; }

    }
}
