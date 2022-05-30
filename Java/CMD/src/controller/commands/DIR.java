package controller.commands;

import java.io.File;
import java.util.Date;

import controller.commandExcution;
import model.DirectoryData;
import utility.Constant;
import view.CommandResult;

public class DIR extends Command implements commandExcution {
	public DIR(CommandResult commandResult, DirectoryData directoryData) {
		super(commandResult, directoryData);
		// TODO Auto-generated constructor stub
	}
	@Override
	public void excuteCommand(String command) {
		// TODO Auto-generated method stub
		synchronizeFile();
		movePath(command);
		if(path.exists()) {
			if(path.isDirectory())
				findDirectoryData();
			else if(path.isFile())
				findFileData();
		}
		else {
			commandResult.showDiskData(getPath(path));
			commandResult.announceFileFindFailed();
		}
	}
	private void findDirectoryData() {
		File[] files=path.listFiles();
		int directoryCount=0;
		int fileCount=0;
		long fileByte=0;
		commandResult.showDiskData(getPath(path));
		if(getPath(path.getParentFile())!="") {
			directoryCount+=2;
			addCurrentAndParentData();
		}
		for(int count=0;count<files.length;count++) {
			if(!files[count].isHidden()) {
				Date lastModified=new Date(files[count].lastModified());
				if(files[count].isDirectory()) {
					directoryCount++;
					commandResult.showDirectoryData(lastModified,"<DIR>",files[count].getName());
				}
				else if(files[count].isFile()) {
					fileCount++;
					fileByte+=files[count].length();
					commandResult.showFileData(lastModified, files[count].length(), files[count].getName());
				}
			}
		}
		commandResult.showDirectoryByte(directoryCount, fileCount, fileByte, path.getUsableSpace());
	}
	private void addCurrentAndParentData() {
		Date lastModified=new Date(path.lastModified());
		commandResult.showDirectoryData(lastModified,Constant.DIRECTORY,Constant.CURRENTFILE);
		lastModified=new Date(path.getParentFile().lastModified());
		commandResult.showDirectoryData(lastModified,Constant.DIRECTORY,Constant.PARENTFILE);
	}
	private void findFileData() {
		commandResult.showDiskData(getPath(path.getParentFile()));
		Date lastModified=new Date(path.lastModified());
		commandResult.showFileData(lastModified, path.length(), path.getName());
		commandResult.showDirectoryByte(1, 0, path.length(), path.getUsableSpace());
	}
}
