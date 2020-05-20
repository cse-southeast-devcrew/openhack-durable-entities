# Challenge 0: Set up your development environment within a development container

## Challenge Objective
The goal for this challenge is to set up and verify your dev environment in a VS Code dev container.

## Brief Guidance

### Install Prerequisites
Ensure you have a Microsoft Windows 10 or MacOS powered workstation with the following installed:
- [Docker Desktop for Windows/MacOS](https://www.docker.com/products/docker-desktop)
- [Visual Studio Code](https://code.visualstudio.com/)
- [Visual Studio Code - Remote Development Extension Pack](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.vscode-remote-extensionpack)
- [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/)
- [Storage emulator](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator) (Windows) or [create a storage account in Azure](https://docs.microsoft.com/en-us/azure/storage/common/storage-account-create?tabs=azure-portal) (Mac)
- [Postman](https://www.postman.com/downloads/)

### Set up a VS Code dev container

We'll be using a [dev container](https://code.visualstudio.com/docs/remote/containers) for this OpenHack to seamlessly set up your environment. To get started, follow these steps:

1. Install and configure Docker for your operating system.

    Windows / macOS:
    1. Install Docker Desktop for Windows/Mac.
    2. If not using WSL2 on Windows, right-click on the Docker task bar item, select **Settings / Preferences** and update **Resources > File Sharing** with any locations your source code is kept. See [tips and tricks](https://code.visualstudio.com/docs/remote/troubleshooting#_container-tips) for troubleshooting.
    3. Enabling [Windows WSL2 back-end](https://aka.ms/vscode-remote/containers/docker-wsl2): Right-click on the Docker taskbar item and select **Settings**. Check **Use the WSL2 based engine** and verify your distribution is enabled under **Resources > WSL Integration.**

    Linux:

    1. Follow the official install [instructions for Docker CE/EE for your distribution](https://docs.docker.com/install/#supported-platforms). If you are using Docker Compose, follow the [Docker Compose directions](https://docs.docker.com/compose/install/) as well.
    2. Add your user to the `docker` group by using a terminal to run: `sudo usermod -aG docker $USER`
    3. Sign out and back in again so your changes take effect.

### Open the project in your dev container

Next clone the repo locally and set up a dev container for your existing project on your filesystem.

1. Start VS Code, run the **Remote-Containers: Open Folder in Container...** command from the Command Palette (`F1`) or quick actions Status bar item, and select the project folder you would like to set up the container for.
2. Now pick a starting point for your dev container. You can either select a base dev container definition from a filterable list, or use an existing Dockerfile or Docker Compose file if one exists in the folder you selected.
3. After picking the starting point for your container, VS Code will add the dev container configuration files to your project (`.devcontainer/devcontainer.json`).
4. The VS Code window will reload and start building the dev container. A progress notification provides status updates. You only have to build a dev container the first time you open it; opening the folder after the first successful build will be much quicker.
5. After the build completes, VS Code will automatically connect to the container.
You can now interact with your project in VS Code just as you could when opening the project locally. From now on, when you open the project folder, VS Code will automatically pick up and reuse your dev container configuration.

## References
- [VS Code Developing inside a Container](https://code.visualstudio.com/docs/remote/containers)



## Challenge Completion Criteria
By the end of this challenge you should have the necessary prerequisites installed and your own version of the repo in a dev container running in VS Code.