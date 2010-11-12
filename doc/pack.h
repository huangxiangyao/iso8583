#include	<memory.h>
#include	<string.h>
#include 	<stdio.h>
#include	<varargs.h>
#include 	<time.h>
#include 	<sys/ipc.h>
#include 	<sys/msg.h>
#include 	<curses.h>


/**********************************************************************/
extern int date_gettoday(char *fmt, char *strtime);
/**********************************************/
/*功  能：根据格式取得当前日期时间的字符串；	      */
/*输  入：fmt-格式:	CC - 世纪	      */
/*		  	YY - 年		      */
/*		  	MM - 月份	      */
/*		  	DD - 日		      */
/*		  	HH - 小时	      */
/*		  	MI - 分钟	      */
/*		  	SS - 秒钟	      */
/*输  出：strtime-日期字符串；		      */
/*返回值：TRUE-成功，FALSE-不成功;		      */
/**********************************************/

extern int date_get_gwtime(char *fmt, char *strtime);
/**********************************************/
/*功  能：根据格式取得当前格林威治日期时间的字符串；*/
/*输  入：fmt-格式:	CC - 世纪	      */
/*		  	YY - 年		      */
/*		  	MM - 月份	      */
/*		  	DD - 日		      */
/*		  	HH - 小时	      */
/*		  	MI - 分钟	      */
/*		  	SS - 秒钟	      */
/*输  出：strtime-日期字符串；		      */
/*返回值：TRUE-成功，FALSE-不成功;		      */
/**********************************************/

extern int date_verify(char *strfmt, char *strbuf);
/**********************************************/
/*功  能：校验字符串日期是否合法；		      */
/*输  入：strfmt-"CCYYMMDD", 		      */
/*	 strbuf-日期字符串；		      */
/*返回值：TRUE-合法，FALSE-不合法;		      */
/**********************************************/

/**********************************************************************/
extern char * del_ablank(char * str);
/********************************/
/*功  能：删除字符串前面与后面的空格*/
/*输  入：str	- 需要处理的字符串*/
/*输  出：str	- 处理后的字符串  */
/*返  回：处理后的字符串（指针）   */
/********************************/


extern char * str_limitlen(char * str, char ch, int flag, int len);
/**********************************************/
/*功  能：将字符串用给定字符补齐到给定的长度；     */
/*输  入：str	- 需要处理的字符串	      */
/*	 ch 	- 用于填充的字符		      */
/*	 flag 	- 1：前面补齐；		      */
/*	 	- 0: 后面补齐		      */
/*	 len	- 补齐后的长度		      */
/*输  出：str-处理后的字符串；		      */
/*返回值：处理后的字符串（指针）;		      */
/**********************************************/

struct ISO8583 {
	short bit_flag;        
	char  data_name[37];   
	short length;          
	short attribute;       
	short variable_flag;   
	short length_in_byte;  
	char  *data;           
};

extern struct ISO8583 master[128];
extern struct ISO8583 visa[128];
extern int unpack_master_8583(char *buf);
extern int visa_master_8583(char *buf);


#define		QUEUESIZE		8192
typedef struct queue	QUEUE;
struct queue {
	long	type;
	char	text[QUEUESIZE];
};

#define WB_SEND_QUEUE	0x11111111
#define WB_RECV_QUEUE	0x22222222
#define WB_MANG_QUEUE	0x33333333
#define MONITOR_QUEUE	0x2002

extern int send_queue(key_t key, char *msg, size_t msglen, long msgtype, int msgflg);
/********************************************************/
/*	功能:	向消息队列发送信息				*/
/*	参数:						*/
/*		key_t	:	消息队列键值		*/
/*		char *	:	消息存放地址		*/
/*		size_t	:	消息长度			*/
/*		long	:	消息发送类型(必须>0)	*/
/*		int	:	IPC_NOWAIT		*/
/*				0			*/
/*	返回:						*/
/*		TRUE	:	成功			*/
/*		FALSE	:	失败			*/
/********************************************************/
extern int recv_queue(key_t key, char *msg, long *rettype, long msgtype, int msgflg);
/***********************************************************/
/*	功能:	从消息队列接收信息				   */
/*	输入:						   */
/*		key_t	:	消息队列键值		   */
/*		char *	:	消息存放地址		   */
/*		long 	:	消息接收类型		   */
/*				=0∶	从队列中接收第一条消息*/
/*				>0:	接收消息类型相同的消息*/
/*		int	:	IPC_NOWAIT		   */
/*				0			    */
/*	返回:						    */
/*	输出：	long *	：	接收到的消息类型		    */
/*		>0	:	成功(值为消息长度)	    */
/*		FALSE	:	失败			    */
/************************************************************/
