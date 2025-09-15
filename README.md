
# 🧾 HTML Page Builder Console App

## Overview

This is a simple C# console application that allows users to interactively build and edit an HTML page. Users can set the title, header, footer, add paragraphs and images, insert CSS and JavaScript, and save the final HTML to a file. The app is designed to be intuitive and menu-driven, making it easy to create basic web pages without needing to write HTML manually.

---

## Features

- ✅ Set page title
- ✅ Set header and footer text
- ✅ Add paragraphs and images with custom IDs
- ✅ Insert custom CSS and JavaScript
- ✅ Clear main content section
- ✅ Save the generated HTML to a file (`page.html`)
- ✅ View live preview of the current HTML markup in the console

---

## Usage

1. **Run the application** using a C# compiler or IDE.
2. **Choose an option** from the menu by entering the corresponding number.
3. **Follow prompts** to input content (e.g., title, paragraph text, image URL).
4. **View the generated HTML** in the console after each action.
5. **Save your work** by selecting the "SaveToFile" option.
6. **Exit** the application when you're done.

---

## Menu Options

| Option Number | Description              |
|---------------|--------------------------|
| 1             | Set page title           |
| 2             | Set header text          |
| 3             | Add a paragraph          |
| 4             | Add an image             |
| 5             | Set footer text          |
| 6             | Add JavaScript code      |
| 7             | Add CSS code             |
| 8             | Save HTML to file        |
| 9             | Clear main content       |
| 10            | Exit the application     |

---

## Output

The generated HTML file (`page.html`) includes:

- `<title>` tag
- `<header>` with header text
- `<main>` section with paragraphs and images
- `<footer>` with footer text
- Embedded `<style>` and `<script>` sections

---

## Requirements

- .NET SDK or compatible C# compiler
- Console environment (Windows, macOS, or Linux)

---

## Example

Here’s a snippet of what the generated HTML might look like:

```html
<!DOCTYPE html>
<html>
<head>
    <title>My Page</title>
    <style>/* Your CSS here */</style>
</head>
<body>
    <header><h1>Welcome!</h1></header>
    <main>
        <p id="intro">This is a paragraph.</p>
        <img id="logo" src="logo.png" alt="Image" />
    </main>
    <footer>Thank you for visiting.</footer>
    <script>// Your JavaScript here</script>
</body>
</html>
```

---

## License

This project is open-source and free to use for educational or personal purposes.

