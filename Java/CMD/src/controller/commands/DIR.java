package controller.commands;

import java.io.File;
import java.util.Date;
import controller.CommandExcution;
import model.DirectoryData;
import utility.Constant;
import view.CommandResult;

public class DIR extends Command implements CommandExcution {
	public DIR(CommandResult commandResult, DirectoryData directoryData) {
		super(commandResult, directoryData);
	}
	@Override
	public void excuteCommand(String command) {
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
		commandResult.addLine();
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
			if(!files[count].isHidden()) {//숨겨진 폴더 출력안함
				Date lastModified=new Date(files[count].lastModified());
				if(files[count].isDirectory()) {//내부 요소가 폴더일 때
					directoryCount++;
					commandResult.showDirectoryData(lastModified,"<DIR>",files[count].getName());
				}
				else if(files[count].isFile()) {//내부 요소가 파일일 때
					fileCount++;
					fileByte+=files[count].length();
					commandResult.showFileData(lastModified, files[count].length(), files[count].getName());
				}
			}
		}
		commandResult.showDirectoryByte(directoryCount, fileCount, fileByte, path.getUsableSpace());
	}
	private void addCurrentAndParentData() {//현재 디렉터리와 부모 디렉터리 dir에 추가
		Date lastModified=new Date(path.lastModified());
		commandResult.showDirectoryData(lastModified,Constant.DIRECTORY,Constant.CURRENTFILE);
		lastModified=new Date(path.getParentFile().lastModified());
		commandResult.showDirectoryData(lastModified,Constant.DIRECTORY,Constant.PARENTFILE);
	}
	private void findFileData() {//현재 디렉터리 내의 파일 dir에 출력
		commandResult.showDiskData(getPath(path.getParentFile()));
		Date lastModified=new Date(path.lastModified());
		commandResult.showFileData(lastModified, path.length(), path.getName());
		commandResult.showDirectoryByte(1, 0, path.length(), path.getUsableSpace());
	}
}
