package controller.commands;
import view.*;

import java.io.File;

import controller.commandExcution;
import model.*;
public class CD extends Command implements commandExcution {
	public CD(CommandResult commandResult, DirectoryData directoryData) {
		super(commandResult, directoryData);
		// TODO Auto-generated constructor stub
	}
	@Override
	public void excuteCommand(String command) {
		// TODO Auto-generated method stub
		synchronizeFile();
		setCdBranch(command);
	}
	private void setCdBranch(String extraLine) {
		String extraCommand=extraLine.trim();
		if(extraCommand.equals(""))
			commandResult.showDirectory(path.getAbsolutePath());
		movePath(extraCommand);
		checkAndSetPath();
	}
	private void checkAndSetPath() {
		if(path.exists()) {
			if(!path.isDirectory()) {
				commandResult.announceIsNotDirectory();
			}
			try {
				directoryData.setDirectory(path.getCanonicalPath());
			}
			catch(Exception e) {
				System.out.println(e.getCause());
				commandResult.announcePathFindFailed();
				return;
			}
		}
		else
			commandResult.announcePathFindFailed();
	}
}
