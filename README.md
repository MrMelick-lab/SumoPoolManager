<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About SumoPoolManager

This console app is used to calculate the scores up to a day of the basho of participants of a pool during a basho tournament. Each of the participants chooses rikishis and the program to calculate for each day their scores. 

This project was built to test some of .net 7 new features and to automate a tedious task.



### Built With

[![dotnet][dotnet.com]][dotnet-url]
[![HtmlAgilityPack][HtmlAgilityPack-logo]][HtlmlAgilityPack-url]

<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites
* [dotnet 7 sdk](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

### Installation

_Below is an example of how you can instruct your audience on installing and setting up your app. This template doesn't rely on any external dependencies or services._

1.  Clone the repo
   ```sh
   git clone https://github.com/MrMelick-lab/SumoPoolManager.git
   ```
2. Open the solution (.sln file) with Visual Studio

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- USAGE EXAMPLES -->
## Usage

To use give a valid path to a json file describing the Pool and the day up to calculate the score, it goes from 1 to 15.
The timestamp id is the identifier of a sumo wrestling tournament with the format YYYYMM. So the basho of new year basho of 2023 wich happens in januray have the id 202301

json schema for the input file in argument:
{
  "type": "object",
  "properties": {
    "TimestampId": {
      "type": "string"
    },
    "Participants": {
      "type": "array",
      "items": {
        "type": "object",
        "properties": {
          "Name": {
            "type": "string"
          },
          "Rikishis": {
            "type": "array",
            "items": {
              "type": "object",
              "properties": {
                "Name": {
                  "type": "string"
                }
              },
              "required": [
                "Name"
              ]
            }
          }
        },
        "required": [
          "Name",
          "Rikishis"
        ]
      }
    }
  },
  "required": [
    "TimestampId",
    "Participants"
  ]
}


<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap
- [ ] Add GUI
- [ ] Add file exportation of the result

See the [open issues](https://github.com/othneildrew/Best-README-Template/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Project Link: [https://github.com/your_username/repo_name](https://github.com/your_username/repo_name)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

Use this space to list resources you find helpful and would like to give credit to. I've included a few of my favorites to kick things off!

* [Choose an Open Source License](https://choosealicense.com)
* [GitHub Emoji Cheat Sheet](https://www.webpagefx.com/tools/emoji-cheat-sheet)
* [Malven's Flexbox Cheatsheet](https://flexbox.malven.co/)
* [Malven's Grid Cheatsheet](https://grid.malven.co/)
* [Img Shields](https://shields.io)
* [GitHub Pages](https://pages.github.com)
* [Font Awesome](https://fontawesome.com)
* [React Icons](https://react-icons.github.io/react-icons/search)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/othneildrew/Best-README-Template.svg?style=for-the-badge
[contributors-url]: https://github.com/othneildrew/Best-README-Template/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/othneildrew/Best-README-Template.svg?style=for-the-badge
[forks-url]: https://github.com/othneildrew/Best-README-Template/network/members
[stars-shield]: https://img.shields.io/github/stars/othneildrew/Best-README-Template.svg?style=for-the-badge
[stars-url]: https://github.com/othneildrew/Best-README-Template/stargazers
[issues-shield]: https://img.shields.io/github/issues/othneildrew/Best-README-Template.svg?style=for-the-badge
[issues-url]: https://github.com/othneildrew/Best-README-Template/issues
[license-shield]: https://img.shields.io/github/license/othneildrew/Best-README-Template.svg?style=for-the-badge
[license-url]: https://github.com/othneildrew/Best-README-Template/blob/master/LICENSE.txt
[dotnet-url]: https://dotnet.microsoft.com/en-us/
[dotnet.com]:https://raw.githubusercontent.com/dotnet/brand/29878855347e055ff15675471f7043fda3e92cea/logo/dotnet-logo.svg
[HtlmlAgilityPack-url]: https://html-agility-pack.net/
[HtmlAgilityPack-logo]: https://z2c2b4z9.stackpathcdn.com/images/logo256X256.png

