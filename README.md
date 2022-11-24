# Strava Stats
![Build Status](https://github.com/mmoiyadi/StravaStats/actions/workflows/dotnet.yml/badge.svg)

This API can be used to fetch the statistical data for an athlete provided by [Strava Stats API](https://developers.strava.com/docs/reference/#api-Athletes-getStats). You need to have an account with Strava in order to be able to use this API. Strava API needs authentication to make a call to their API in the form of access token. The access token expires every six hours. In order to generate access token, we need to call [Strava's Oauth API](https://developers.strava.com/docs/authentication/) alongwith client secret, client id and refresh token which can be found on [Strava Settings](https://www.strava.com/settings/api) page. __StravaStats__ API takes care of generating the access token for you. You just need to provide client secret, client id, refresh token and athlete id in the config file and just run the API to get your statistics. 

Cheers!!!



