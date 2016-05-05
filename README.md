## MarketAmerica Android Demo 
This is a sample mobile application that builds an Android (apk) application that you can install and test. 

## What does it do?
1. Connects to the Market America API to gain access to a catalog of 1000s of products
2. Uses the Search API and the Product API to collect information about the Automotive products that are sold by MA.
3. Displays categories to your user. The user can tap a category and then view products. You can tap a product and then view the product details.

## What platform is this application built on?
This application takes a hybrid approach. The framework is Xamarin and the programming language is C#. The Xamarin framework allows one to build an app that has native functionality, all while programming in the familiar C# language. 

## How can I run? 
Download the APK and install. 
https://github.com/DannyAllegrezza/MarketAmerica/blob/master/MarketAmerica.Droid/MarketAmerica.Droid.MarketAmerica.Droid-Aligned.apk

## What should I expect when it runs?
1. You will see a list of Categories to choose from. Each category displayed is part of the Automotive category.
2. Once you tap a Category, you will see a list of 15 products 
3. Tap the Product to view more details

## TODO:
There is a LOT left to do in this project. This was my first time building any type of mobile application, so the majority of my time was spent learning about mobile application development, understanding the Xamarin framework, and understanding the API I was trying to connect to.

1. Add Search
2. Add some kind of pagination system
3. Add ability to load a product into the browser 
4. Add splash screen and some kind of progress bar as each Activity transistions
5. Implement more multi-threaded calls
3. Optimize style
4. Optimize process heavy tasks ( such as downloading the image and converting it to a bitmap )
5. Lots and lots of learning about Android Development
