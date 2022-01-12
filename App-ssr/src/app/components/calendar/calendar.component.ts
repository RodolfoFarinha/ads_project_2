import { Component, ChangeDetectionStrategy, ViewChild, TemplateRef, OnInit} from '@angular/core';
import { startOfDay, endOfDay, subDays, addDays, endOfMonth, isSameDay, isSameMonth, addHours} from 'date-fns';
import { Subject } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CalendarEvent, CalendarEventAction, CalendarEventTimesChangedEvent, CalendarView } from 'angular-calendar';
import { SharedQualityScheduleService } from 'src/app/util/shared-quality-schedule/SharedQualitySchedule.service';
import { ScheduleType } from 'src/app/util/enums/ScheduleType.enum';
import { EventCalendar } from 'src/app/models/business/EventCalendar';
import { QualitySchedule } from 'src/app/models/entities/QualitySchedule';

const colors: any = {
  blue: {
    primary: '#1e90ff',
    secondary: '#D1E8FF',
  },
  yellow: {
    primary: '#e3bc08',
    secondary: '#FDF1BA',
  },
  green: {
    primary: '#63DA63',
    secondary: '#11BD11',
  },
  pink: {
    primary: '#E373DF',
    secondary: '#FF33F9',
  },
  red: {
    primary: '#ad2121',
    secondary: '#FAE3E3',
  },
};

@Component({
  selector: 'mwl-demo-component',
  changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrls: ['calendar.component.css'],
  templateUrl: 'calendar.component.html',
})
export class CalendarComponent implements OnInit {
  @ViewChild('modalContent', { static: true }) modalContent: TemplateRef<any> | undefined;

  view: CalendarView = CalendarView.Month;

  CalendarView = CalendarView;

  viewDate: Date = new Date("2015-10-01T00:00:00");

  modalData: {
    action: string;
    event: CalendarEvent;
  } | undefined;

  actions: CalendarEventAction[] = [
    {
      label: '<i class="fas fa-fw fa-pencil-alt"></i>',
      a11yLabel: 'Edit',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.handleEvent('Edited', event);
      },
    },
    {
      label: '<i class="fas fa-fw fa-trash-alt"></i>',
      a11yLabel: 'Delete',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.events = this.events.filter((iEvent) => iEvent !== event);
        this.handleEvent('Deleted', event);
      },
    },
  ];

  refresh: Subject<any> = new Subject();

  // events: CalendarEvent[] = [
  //   {
  //     start: subDays(startOfDay(new Date()), 1),
  //     end: addDays(new Date(), 1),
  //     title: 'A 3 day event',
  //     color: colors.red,
  //     actions: this.actions,
  //     allDay: true,
  //     resizable: {
  //       beforeStart: true,
  //       afterEnd: true,
  //     },
  //     draggable: true,
  //   },
  //   {
  //     start: startOfDay(new Date()),
  //     title: 'An event with no end date',
  //     color: colors.yellow,
  //     actions: this.actions,
  //   },
  //   {
  //     start: subDays(endOfMonth(new Date()), 3),
  //     end: addDays(endOfMonth(new Date()), 3),
  //     title: 'A long event that spans 2 months',
  //     color: colors.blue,
  //     allDay: true,
  //   },
  //   {
  //     start: addHours(startOfDay(new Date()), 2),
  //     end: addHours(new Date(), 2),
  //     title: 'A draggable and resizable event',
  //     color: colors.yellow,
  //     actions: this.actions,
  //     resizable: {
  //       beforeStart: true,
  //       afterEnd: true,
  //     },
  //     draggable: true,
  //   },
  // ];

  events: CalendarEvent[] = [];

  activeDayIsOpen: boolean = true;

  scheduleTypesEnum = ScheduleType;
  scheduleTypes: string[];

  eventsNormal: EventCalendar[];
  eventsOverBooking25: EventCalendar[];
  roomCloseCapacity: EventCalendar[];
  randomOrder: EventCalendar[];
  allVariables: EventCalendar[];

  qualitySchedules: QualitySchedule[] = [];

  constructor(private modal: NgbModal, private sharedQualityScheduleService: SharedQualityScheduleService) { }

  ngOnInit() {
    this.scheduleTypes = Object.keys(this.scheduleTypesEnum);

    this.sharedQualityScheduleService.getGlobalQualitySchedule()?.forEach(qualitySchedule => {

      switch (qualitySchedule.scheduleType.toString()) {
        case '0':
          this.eventsNormal = qualitySchedule.eventsCalendar;
          break;
        case '1':
          this.eventsOverBooking25 = qualitySchedule.eventsCalendar;
          break;
        case '2':
          this.roomCloseCapacity = qualitySchedule.eventsCalendar;
          break;
        case '3':
          this.randomOrder = qualitySchedule.eventsCalendar;
          break;
        case '4':
          this.allVariables = qualitySchedule.eventsCalendar;
          break;
      }

      this.eventsNormal.forEach(eventCalendar => {
        this.events.push({
          start: new Date(eventCalendar.start.toString()),
          end: new Date(eventCalendar.end.toString()),
          title: eventCalendar.title,
          color: colors.blue,
          actions: this.actions,
          resizable: {
            beforeStart: true,
            afterEnd: true,
          },
          draggable: true,
        });
      });
    });
  }

  dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
    if (isSameMonth(date, this.viewDate)) {
      if (
        (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
        events.length === 0
      ) {
        this.activeDayIsOpen = false;
      } else {
        this.activeDayIsOpen = true;
      }
      this.viewDate = date;
    }
  }

  eventTimesChanged({event, newStart, newEnd}: CalendarEventTimesChangedEvent): void {
    this.events = this.events.map((iEvent) => {
      if (iEvent === event) {
        return {
          ...event,
          start: newStart,
          end: newEnd,
        };
      }
      return iEvent;
    });
    this.handleEvent('Dropped or resized', event);
  }

  handleEvent(action: string, event: CalendarEvent): void {
    this.modalData = { event, action };
    this.modal.open(this.modalContent, { size: 'lg' });
  }

  addEvent(): void {
    this.events = [
      ...this.events,
      {
        title: 'New event',
        start: startOfDay(new Date()),
        end: endOfDay(new Date()),
        color: colors.red,
        draggable: true,
        resizable: {
          beforeStart: true,
          afterEnd: true,
        },
      },
    ];
  }

  deleteEvent(eventToDelete: CalendarEvent) {
    this.events = this.events.filter((event) => event !== eventToDelete);
  }

  setView(view: CalendarView) {
    this.view = view;
  }

  closeOpenMonthViewDay() {
    this.activeDayIsOpen = false;
  }

  changeAlgorithm(event) {
    this.events = [];
    switch (event) {
      case "Normal":
        this.eventsNormal.forEach(eventCalendar => {
          this.events.push({
            start: new Date(eventCalendar.start.toString()),
            end: new Date(eventCalendar.end.toString()),
            title: eventCalendar.title,
            color: colors.blue,
            actions: this.actions,
            resizable: {
              beforeStart: true,
              afterEnd: true,
            },
            draggable: true,
          });
        });
        break;
      case "OverBooking25":
        this.eventsOverBooking25.forEach(eventCalendar => {
          this.events.push({
            start: new Date(eventCalendar.start.toString()),
            end: new Date(eventCalendar.end.toString()),
            title: eventCalendar.title,
            color: colors.yellow,
            actions: this.actions,
            resizable: {
              beforeStart: true,
              afterEnd: true,
            },
            draggable: true,
          });
        });
        break;
      case "RoomCloseCapacity":
        this.roomCloseCapacity.forEach(eventCalendar => {
          this.events.push({
            start: new Date(eventCalendar.start.toString()),
            end: new Date(eventCalendar.end.toString()),
            title: eventCalendar.title,
            color: colors.green,
            actions: this.actions,
            resizable: {
              beforeStart: true,
              afterEnd: true,
            },
            draggable: true,
          });
        });
        break;
      case "RandomOrder":
        this.randomOrder.forEach(eventCalendar => {
          this.events.push({
            start: new Date(eventCalendar.start.toString()),
            end: new Date(eventCalendar.end.toString()),
            title: eventCalendar.title,
            color: colors.pink,
            actions: this.actions,
            resizable: {
              beforeStart: true,
              afterEnd: true,
            },
            draggable: true,
          });
        });
        break;
      case "AllVariables":
        this.allVariables.forEach(eventCalendar => {
          this.events.push({
            start: new Date(eventCalendar.start.toString()),
            end: new Date(eventCalendar.end.toString()),
            title: eventCalendar.title,
            color: colors.red,
            actions: this.actions,
            resizable: {
              beforeStart: true,
              afterEnd: true,
            },
            draggable: true,
          });
        });
        break;
    }
  }
}
