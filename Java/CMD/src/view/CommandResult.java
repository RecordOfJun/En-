package view;

import java.io.File;
import java.nio.file.FileStore;
import java.nio.file.FileSystem;
import java.nio.file.FileSystems;
import java.text.SimpleDateFormat;
import java.util.Date;
import javax.swing.filechooser.FileSystemView;
public class CommandResult {
	public void showAllCommand() {
		System.out.println("특정 명령어에 대한 자세한 내용이 필요하면 HELP 명령어 이름을 입력하십시오.\r\n"
				+ "ASSOC    파일 확장명 연결을 보여주거나 수정합니다.\r\n"
				+ "ATTRIB   파일 속성을 표시하거나 바꿉니다.\r\n"
				+ "BREAK    확장된 CTRL+C 검사를 설정하거나 지웁니다.\r\n"
				+ "BCDEDIT        부팅 로딩을 제어하기 위해 부팅 데이터베이스에서 속성을 설정합니다.\r\n"
				+ "CACLS    파일의 액세스 컨트롤 목록(ACL)을 표시하거나 수정합니다.\r\n"
				+ "CALL     한 일괄 프로그램에서 다른 일괄 프로그램을 호출합니다.\r\n"
				+ "CD       현재 디렉터리 이름을 보여주거나 바꿉니다.\r\n"
				+ "CHCP     활성화된 코드 페이지의 번호를 표시하거나 설정합니다.\r\n"
				+ "CHDIR    현재 디렉터리 이름을 보여주거나 바꿉니다.\r\n"
				+ "CHKDSK   디스크를 검사하고 상태 보고서를 표시합니다.\r\n"
				+ "CHKNTFS  부팅하는 동안 디스크 확인을 화면에 표시하거나 변경합니다.\r\n"
				+ "CLS      화면을 지웁니다.\r\n"
				+ "CMD      Windows 명령 인터프리터의 새 인스턴스를 시작합니다.\r\n"
				+ "COLOR    콘솔의 기본색과 배경색을 설정합니다.\r\n"
				+ "COMP     두 개 또는 여러 개의 파일을 비교합니다.\r\n"
				+ "COMPACT  NTFS 분할 영역에 있는 파일의 압축을 표시하거나 변경합니다.\r\n"
				+ "CONVERT  FAT 볼륨을 NTFS로 변환합니다. 현재 드라이브는\r\n"
				+ "         변환할 수 없습니다.\r\n"
				+ "COPY     하나 이상의 파일을 다른 위치로 복사합니다.\r\n"
				+ "DATE     날짜를 보여주거나 설정합니다.\r\n"
				+ "DEL      하나 이상의 파일을 지웁니다.\r\n"
				+ "DIR      디렉터리에 있는 파일과 하위 디렉터리 목록을 보여줍니다.\r\n"
				+ "DISKPART       디스크 파티션 속성을 표시하거나 구성합니다.\r\n"
				+ "DOSKEY       명령줄을 편집하고, Windows 명령을 다시 호출하고,\r\n"
				+ "               매크로를 만듭니다.\r\n"
				+ "DRIVERQUERY    현재 장치 드라이버 상태와 속성을 표시합니다.\r\n"
				+ "ECHO           메시지를 표시하거나 ECHO를 켜거나 끕니다.\r\n"
				+ "ENDLOCAL       배치 파일에서 환경 변경의 지역화를 끝냅니다.\r\n"
				+ "ERASE          하나 이상의 파일을 지웁니다.\r\n"
				+ "EXIT           CMD.EXE 프로그램(명령 인터프리터)을 종료합니다.\r\n"
				+ "FC             두 파일 또는 파일 집합을 비교하여 다른 점을\r\n"
				+ "         표시합니다.\r\n"
				+ "FIND           파일에서 텍스트 문자열을 검색합니다.\r\n"
				+ "FINDSTR        파일에서 문자열을 검색합니다.\r\n"
				+ "FOR            파일 집합의 각 파일에 대해 지정된 명령을 실행합니다.\r\n"
				+ "FORMAT         Windows에서 사용할 디스크를 포맷합니다.\r\n"
				+ "FSUTIL         파일 시스템 속성을 표시하거나 구성합니다.\r\n"
				+ "FTYPE          파일 확장명 연결에 사용되는 파일 형식을 표시하거나\r\n"
				+ "               수정합니다.\r\n"
				+ "GOTO           Windows 명령 인터프리터가 일괄 프로그램에서\r\n"
				+ "               이름표가 붙여진 줄로 이동합니다.\r\n"
				+ "GPRESULT       컴퓨터 또는 사용자에 대한 그룹 정책 정보를 표시합니다.\r\n"
				+ "GRAFTABL       Windows가 그래픽 모드에서 확장 문자 세트를 표시할\r\n"
				+ "         수 있게 합니다.\r\n"
				+ "HELP           Windows 명령에 대한 도움말 정보를 제공합니다.\r\n"
				+ "ICACLS         파일과 디렉터리에 대한 ACL을 표시, 수정, 백업 또는\r\n"
				+ "               복원합니다.\r\n"
				+ "IF             일괄 프로그램에서 조건 처리를 수행합니다.\r\n"
				+ "LABEL          디스크의 볼륨 이름을 만들거나, 바꾸거나, 지웁니다.\r\n"
				+ "MD             디렉터리를 만듭니다.\r\n"
				+ "MKDIR          디렉터리를 만듭니다.\r\n"
				+ "MKLINK         바로 가기 링크와 하드 링크를 만듭니다.\r\n"
				+ "MODE           시스템 장치를 구성합니다.\r\n"
				+ "MORE           출력을 한번에 한 화면씩 표시합니다.\r\n"
				+ "MOVE           하나 이상의 파일을 한 디렉터리에서 다른 디렉터리로\r\n"
				+ "               이동합니다.\r\n"
				+ "OPENFILES      파일 공유에서 원격 사용자에 의해 열린 파일을 표시합니다.\r\n"
				+ "PATH           실행 파일의 찾기 경로를 표시하거나 설정합니다.\r\n"
				+ "PAUSE          배치 파일의 처리를 일시 중단하고 메시지를 표시합니다.\r\n"
				+ "POPD           PUSHD에 의해 저장된 현재 디렉터리의 이전 값을\r\n"
				+ "               복원합니다.\r\n"
				+ "PRINT          텍스트 파일을 인쇄합니다.\r\n"
				+ "PROMPT         Windows 명령 프롬프트를 변경합니다.\r\n"
				+ "PUSHD          현재 디렉터리를 저장한 다음 변경합니다.\r\n"
				+ "RD             디렉터리를 제거합니다.\r\n"
				+ "RECOVER        불량이거나 결함이 있는 디스크에서 읽을 수 있는 정보를 복구합니다.\r\n"
				+ "REM            배치 파일 또는 CONFIG.SYS에 주석을 기록합니다.\r\n"
				+ "REN            파일 이름을 바꿉니다.\r\n"
				+ "RENAME         파일 이름을 바꿉니다.\r\n"
				+ "REPLACE        파일을 바꿉니다.\r\n"
				+ "RMDIR          디렉터리를 제거합니다.\r\n"
				+ "ROBOCOPY       파일과 디렉터리 트리를 복사할 수 있는 고급 유틸리티입니다.\r\n"
				+ "SET            Windows 환경 변수를 표시, 설정 또는 제거합니다.\r\n"
				+ "SETLOCAL       배치 파일에서 환경 변경의 지역화를 시작합니다.\r\n"
				+ "SC             서비스(백그라운드 프로세스)를 표시하거나 구성합니다.\r\n"
				+ "SCHTASKS       컴퓨터에서 실행할 명령과 프로그램을 예약합니다.\r\n"
				+ "SHIFT          배치 파일에서 바꿀 수 있는 매개 변수의 위치를 바꿉니다.\r\n"
				+ "SHUTDOWN       컴퓨터의 로컬 또는 원격 종료를 허용합니다.\r\n"
				+ "SORT           입력을 정렬합니다.\r\n"
				+ "START          지정한 프로그램이나 명령을 실행할 별도의 창을 시작합니다.\r\n"
				+ "SUBST          경로를 드라이브 문자에 연결합니다.\r\n"
				+ "SYSTEMINFO     컴퓨터별 속성과 구성을 표시합니다.\r\n"
				+ "TASKLIST       서비스를 포함하여 현재 실행 중인 모든 작업을 표시합니다.\r\n"
				+ "TASKKILL       실행 중인 프로세스나 응용 프로그램을 중단합니다.\r\n"
				+ "TIME           시스템 시간을 표시하거나 설정합니다.\r\n"
				+ "TITLE          CMD.EXE 세션에 대한 창 제목을 설정합니다.\r\n"
				+ "TREE           드라이브 또는 경로의 디렉터리 구조를 그래픽으로\r\n"
				+ "               표시합니다.\r\n"
				+ "TYPE           텍스트 파일의 내용을 표시합니다.\r\n"
				+ "VER            Windows 버전을 표시합니다.\r\n"
				+ "VERIFY         파일이 디스크에 올바로 기록되었는지 검증할지\r\n"
				+ "         여부를 지정합니다.\r\n"
				+ "VOL            디스크 볼륨 레이블과 일련 번호를 표시합니다.\r\n"
				+ "XCOPY          파일과 디렉터리 트리를 복사합니다.\r\n"
				+ "WMIC           대화형 명령 셸 내의 WMI 정보를 표시합니다.\r\n"
				+ "\r\n"
				+ "도구에 대한 자세한 내용은 온라인 도움말의 명령줄 참조를 참조하십시오.");
	}
	public void clearConsole() {
		for(int line=0;line<30;line++)
			System.out.println();
	}
	public void showDirectory(String path) {
		System.out.println(path);
	}
	public void showDiskData(String path) {
		System.out.println(" C 드라이브의 볼륨: Local Disk");
		//System.out.println(" 볼륨 일련 번호: "+FileStore a);
		System.out.println();
		System.out.println(String.format(" %s 디렉터리", path));
		System.out.println();
	}
	public void showDirectoryData(Date lastModified,String DIR,String fileName) {
		SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd aa hh:mm");
		System.out.println(dateFormat.format(lastModified)+String.format("    %-15s%s",DIR,fileName));
	}
	public void showFileData(Date lastModified,long fileByte,String fileName) {
		SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd aa hh:mm");
		System.out.println(dateFormat.format(lastModified)+String.format("%,18d %s",fileByte ,fileName));
	}
	public void showDirectoryByte(int directoryCount,int fileCount,long fileByte,long usableByte) {
		System.out.println(String.format("%15d개 파일  %,16d 바이트",fileCount,fileByte));
		System.out.println(String.format("%15d개 디렉터리%,16d 바이트 남음",directoryCount,usableByte));
	}
	public void announceWrongCommand() {
		System.out.println("명령 구문이 올바르지 않습니다.");
	}
	public void announcePathFindFailed() {
		System.out.println("지정된 경로를 찾을 수 없습니다.");
	}
	public void announceIsNotDirectory() {
		System.out.println("디렉터리 이름이 올바르지 않습니다.");
	}
	public void announceFileFindFailed() {
		System.out.println("파일을 찾을 수 없습니다.");
	}
	public void announceCanNotCopySameFile() {
		System.out.println("같은 파일로 복사할 수 없습니다.");
		announceCopyComplete(0);
	}
	public void announceCopyComplete(int count) {
		System.out.println(String.format("     %d개 파일이 복사되었습니다.",count));
	}
	public void askCover(String rightPath) {
		System.out.print(rightPath+"을(를) 덮어쓰시겠습니까? (Yes/No/All):");
	}
}
