using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubstringController : ControllerBase
    {
        [HttpGet("longest-substring")]
        public IActionResult GetLongestSubstring([FromQuery] string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return BadRequest("Input string cannot be empty.");
            }

            int maxLength = LengthOfLongestSubstring(input);
            return Ok(new { Input = input, MaxLength = maxLength });
        }

        private int LengthOfLongestSubstring(string s)
        {
            var charSet = new HashSet<char>();
            int maxLength = 0, left = 0;

            for (int right = 0; right < s.Length; right++)
            {
                while (charSet.Contains(s[right]))
                {
                    charSet.Remove(s[left++]);
                }

                charSet.Add(s[right]);
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }
    }
}
