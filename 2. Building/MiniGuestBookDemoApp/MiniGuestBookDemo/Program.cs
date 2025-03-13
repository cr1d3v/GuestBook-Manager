using MiniGuestBookDemo;

GuestBookLogic.WelcomeIntro();

(List<string> partyNameList, int totalGuests) = GuestBookLogic.GetAllGuestsNum();

GuestBookLogic.PrintGuestsList(partyNameList);

GuestBookLogic.EndApp(totalGuests);
















