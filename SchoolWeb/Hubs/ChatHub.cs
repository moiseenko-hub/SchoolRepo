using Microsoft.AspNetCore.SignalR;
using StoreData.Models;
using StoreData.Repostiroties;
using StoreData.Repostiroties.School;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Hubs;

public class ChatHub : Hub
{
    private readonly SchoolAuthService _authService;
    private readonly SchoolUserRepository _userRepository;
    private readonly MessageRepository _messageRepository;

    public ChatHub(SchoolAuthService authService, SchoolUserRepository userRepository, MessageRepository messageRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
        _messageRepository = messageRepository;
    }

    public async Task AddMessage(string message)
    {
        var username = _authService.GetUserName();
        var user = _userRepository.GetByUsername(username);
        _messageRepository.Add(new MessageData { Message = message, User = user });
        await Clients.All.SendAsync("NewMessage", username, message);
    }
}