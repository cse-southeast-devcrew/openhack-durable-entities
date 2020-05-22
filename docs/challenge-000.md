# Challenge 0: Set up your development environment within a development container

## Challenge Objective
The goal for this challenge is to set up and verify your dev environment in a VS Code dev container.

## Guidance

### Install Prerequisites
Ensure you have a Microsoft Windows 10 or MacOS powered workstation with the following installed:
- [ ] [Docker Desktop for Windows/MacOS](https://www.docker.com/products/docker-desktop)
- [ ] [Visual Studio Code](https://code.visualstudio.com/)
- [ ] [Visual Studio Code - Remote Development Extension Pack](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.vscode-remote-extensionpack)
- [ ] [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/)
- [ ] [Storage emulator](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator) (Windows) or [create a storage account in Azure](https://docs.microsoft.com/en-us/azure/storage/common/storage-account-create?tabs=azure-portal) (Mac)
- [ ] [Postman](https://www.postman.com/downloads/)

### Set up a VS Code dev container

We'll be using a [dev container](https://code.visualstudio.com/docs/remote/containers) for this OpenHack to seamlessly set up your environment. To get started, follow these steps:

For Windows / macOS:

1. Open Docker Desktop.
2. Right-click on the Docker task bar item, select **Settings / Preferences** and update **Resources > File Sharing** with any locations your source code is kept. See [tips and tricks](https://code.visualstudio.com/docs/remote/troubleshooting#_container-tips) for troubleshooting.

For Linux:

1. Follow the official install [instructions for Docker CE/EE for your distribution](https://docs.docker.com/install/#supported-platforms). If you are using Docker Compose, follow the [Docker Compose directions](https://docs.docker.com/compose/install/) as well.
2. Add your user to the `docker` group by using a terminal to run: `sudo usermod -aG docker $USER`
3. Sign out and back in again so your changes take effect.

### Open and run the project in your dev container

1. Clone the repo to your local machine.
2. Start VS Code, run the **Remote-Containers: Open Folder in Container...** command from the Command Palette (`F1`) or quick actions Status bar item, and select your project folder.
3. The VS Code window will reload and start building the dev container. A progress notification provides status updates. You only have to build a dev container the first time you open it; opening the folder after the first successful build will be much quicker.
4. After the build completes, VS Code will automatically connect to the container.
You can now interact with your project in VS Code just as you could when opening the project locally. From now on, when you open the project folder, VS Code will automatically pick up and reuse your dev container configuration.
5. Build and run the starter code. Set a breakpoint and practice debugging in your environment. You should see the counter updated.

## References
- [VS Code Developing inside a Container](https://code.visualstudio.com/docs/remote/containers)

## Challenge Completion Criteria

- [ ] All of the necessary prerequisites are installed
- [ ] Your project is open in a dev container in VS Code
- [ ] The starter code builds and runs successfully 

## Next Steps
Now that you have your dev environment setup and the starter code running in a dev container in VS Code, it's time to begin processing data from Cosmos.

Proceed to [Challenge 1](challenge-001.md).