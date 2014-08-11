# C-Sharp-Twitter-API-1.1-application-only-auth
for C#  by [Javier Abrego Lorente]

## 0. Index

1. [Description](#1-description)
2. [Installation](#2-installation)	
3. [Usage](#3-usage)
4. [Credits](#4-credits)
5. [Changelog](#5-changelog)
6. [Contribute] (#7-contribute)
7. [License](#6-license)



## 1. Description

This library allows you to comunicate with the version 1.1 of the Twitter API. The library uses Application-only authentication which offers applications the ability to issue authenticated requests on behalf of the application itself (as opposed to on behalf of a specific user). Twitter's implementation is based on the Client Credentials Grant flow of the OAuth 2 specification.
With Application-only authentication you don't have the context of an authenticated user and this means that any request to API for endpoints that require user context, such as posting tweets, will not work. However, the set of endpoints that will still be available can have a higher rate limit.

Your app will be able to, for example:

Pull user timelines;
Access friends and followers of any account;
Access lists resources;
Search in tweets;
Retrieve any user information;
And it won't be able to:

Post tweets or other resources;
Connect in Streaming endpoints;
Search for users;
Use any geo endpoint;
Access DMs or account credentials;

refer to https://dev.twitter.com/docs/auth/application-only-auth for more information

###Auth Flow

The application-only auth flow follows these steps:

An application encodes its consumer key and secret into a specially encoded set of credentials.
An application makes a request to the POST oauth2/token endpoint to exchange these credentials for a bearer token.
When accessing the REST API, the application uses the bearer token to authenticate.

## 2. Installation

The library need NewtonSoft JSON library, you just need to add in references the 2 libraries (.dll) from the bin folder to your project.

You will need too to get the credentials from the twitter developer website and create an application. See https://apps.twitter.com/ for more information.

## 3. Usage
```
[...]

using TwiitterApi;

[...]


APIv1_1 twitter = new APIv1_1();

String api_secret = "yourapisecrethere"; //set your api secret

String api_key = "yourapikeyhere"; //set you api key


twitter.setApiCredentials(api_secret, api_key);

string url = String.Format("https://api.twitter.com/1.1/users/show.json?screen_name={0}", screenName);

String response = twitter.getTwitterDataBearerRequest(url);
```


## 4. Credits
This plugin was  entirely created by [Javier Abrego].


## 5. CHANGELOG

1.0: initial version supporting generic calls to Twitter API and retrieve of User information

### 6. Contribute

If you see an area for improvement, or have an idea for a new feature then we'd love to have your help!
GitHub repo:
```
https://github.com/JavierAbrego/C-Sharp-Twitter-API-1.1-application-only-auth/

```

## 7. License

[The MIT License (MIT)](http://www.opensource.org/licenses/mit-license.html)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

