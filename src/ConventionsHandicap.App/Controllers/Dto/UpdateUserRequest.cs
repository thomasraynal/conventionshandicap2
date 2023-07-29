using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConventionsHandicap.Controller.Dto
{
    public class UpdateUserRequest
    {
        [Required]
        [JsonProperty("workspaceId")]
        public Guid? WorkspaceId { get; set; }
        [Required]
        [JsonProperty("userRole")]
        public ConventionsHandicapUserRole? UserRole { get; set; }
        [JsonProperty("userEmail")]
        public string? UserEmail { get; set; }
        [Required]
        [JsonProperty("userId")]
        public Guid? UserId { get; set; }
    }
}
