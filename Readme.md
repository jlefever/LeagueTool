# League Tool

[Demo](http://leaguetool.azurewebsites.net)

League Tool is an ASP.NET MVC 5 web application that provides a friendly interface for browsing League of Legends champion data. League Tool uses Riot's [Data Dragon](https://developer.riotgames.com/static-data.html) service to access champion data from a user supplied Region, Language, and Game Version. This allows a user to see how a specific champion has changed through versions or how a champion is presented across regions and languages. League Tool uses [Tabler](https://github.com/tabler/tabler) for it's CSS.

## Potential Improvements

1. Add custom 404 and 500 pages.

2. Show champion splash arts on champion detail pages.

3. Cache Data Dragon responses. While Data Dragon is fast, the responses do not change so continually making requests is redundant. Performance could be increased significantly by caching responses in memory.

4. Add actual unit and integration tests

5. Fetch and build Tabler from NPM rather than including it statically in the project.

6. Refactor HomeController into multiple controllers.

## Known Issues

1. An invalid champion name in the url will result in a 500 rather than a 404 page as there is no champion name validation.

2. Some older Data Dragon versions lack specific champions (ex: 3.6.14 lacks Akali). This is a bug with Data Dragon but we should include handling on our end. At the moment we are just 500ing.
