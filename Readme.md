## Introduction

Let's imagine that our company has been asked to track competitor presence in news. In order to do that, an integration with the news provider API is required.  
With this exercise, you will build an ASP.NET Core Web Api allowing to provide that information.

The produced solution should:
* build with `dotnet build` command,
* run with `dotnet run` command and start the local, console instance of the Web Api,
* contain all the necessary tests (unit tests and integration tests) runnable with `dotnet test` command,
* have a documented api showing available operation and the requests/response models.

During writing the service, please include all the good practices that would be normally used during the development of the service.

For obtaining news, please integrate with https://newsapi.org/ using a free Developer account.  
Please feel free to use libraries and nuget packages of your choice, but write API integration using standard tools you know - the [News-API-csharp](https://github.com/News-API-gh/News-API-csharp) should not be used in this code test.

For the implementation, please follow the tickets written below.  
For every ticket, please prepare a separate commit/pull-request showing incremental work.  
Assuming every ticket is implemented and released independently, the changes should be implemented in a non-breaking manner.  

During the interview session, all of the tickets will be demoed, reviewed and discussed.

## Ticket-1

```
As a data moderator,  
I want to know all recent news published about the given company,  
So that I can efficiently provide insights about competitor presence in the news.
```

Please design and create an endpoint returning 5 most recent news for provided **company name**, where the the news should contain **company name** in **news title**, like: `Microsoft`, `HSBC` or `Toyota` and articles written in English language.

The endpoint should use https://newsapi.org/v2/everything for obtaining the news (documentation: https://newsapi.org/docs/endpoints/everything) and return response containing a collection of articles, each including the title, author, source name, published date, article link:

```
[
  {
    "title": "Microsoft Surface event: the 6 biggest announcements",
    "author": "Emma Roth",
    "sourceName": "The Verge",
    "publishedDate": "2023-09-21T15:24:23Z",
    "articleLink": "https://www.theverge.com/2023/9/21/23882074/microsoft-surface-copilot-event-2023-biggest-announcements"
  },
  {}
]
```

## Ticket-2

```
As a data moderator,  
I want to retrieve articles in specified language,  
So that I can provide localised insights about the competitor presence in the news.
```

Assuming that Ticket-1 is implemented and released to production, please extend the **existing endpoint** with an option specify **language** (eg. `en` or `de`) in which the articles are queried.

## Ticket-3

```
As a data moderator,  
I want to be able to specify multiple language codes and retrieve 5 most recent articles in for each provided language,  
So that I can get a good overview of competitor activity across global media.
```

Assuming previous changes are implemented and released to production, please extend the `existing endpoint` with ability to specify comma separated language codes (eg. `en, de, fr`). The response should contain 5 most recent news in each language and each article model should contain the `language` field specifying the language it is written in:

```
[
  {
    "title": "Microsoft Surface event: the 6 biggest announcements",
    "author": "Emma Roth",
    "sourceName": "The Verge",
    "publishedDate": "2023-09-21T15:24:23+00:00",
    "articleLink": "https://www.theverge.com/2023/9/21/23882074/microsoft-surface-copilot-event-2023-biggest-announcements",
    "language": "en"
  },
  {
    "title": "Microsoft consomme énormément d’eau pour inonder le monde d’IA",
    "author": "Thomas Estimbre",
    "sourceName": "Journal du geek",
    "publishedDate": "2023-09-12T14:05:40+00:00",
    "articleLink": "https://www.journaldugeek.com/2023/09/12/microsoft-consomme-enormement-deau-pour-inonder-le-monde-dia/",
    "language": "fr"
  },
  {}
]
```
