package controller.commands;
import view.*;
import controller.CommandExcution;
import model.*;
import utility.Constant;
public class CD extends Command implements CommandExcution {
	public CD(CommandResult commandResult, DirectoryData directoryData) {
		super(commandResult, directoryData);
	}
	@Override
	public void excuteCommand(String command) {
		synchronizeFile();
		setCdBranch(command);
	}
	private void setCdBranch(String extraLine) {
		String extraCommand=extraLine.trim();
		if(extraCommand.equals(Constant.EMPTY))
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
